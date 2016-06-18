using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Telekinesis : MonoBehaviour {

    float lerpTime;
    float currentLerpTime;
    bool pull;
    bool movePlat;
    GameObject moveTarget;
    float perc;
    Transform startPos;
    bool holding;
    List<Transform> objectList;
    Material diffuse;
    GameObject player;

    // Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        lerpTime = 1f;
        currentLerpTime = 0f;
        pull = false;
        holding = false;
        movePlat = false;
        objectList = new List<Transform>();

        GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Plane);
        primitive.SetActive(false);
        diffuse = primitive.GetComponent<MeshRenderer>().sharedMaterial;
        DestroyImmediate(primitive);
    }

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Transform cam = this.transform;
      
        if (currentLerpTime <= lerpTime)
        {
            currentLerpTime += Time.fixedDeltaTime;
        }
        
        for(int i = 0; i < objectList.Count; i++)
        {
            if (!movePlat)
            {
                objectList[i].GetComponent<Renderer>().material = diffuse;
            }
        }
        objectList.Clear();

        if (Physics.SphereCast(cam.position - cam.forward * 1, 1, cam.forward, out hit, 20) && !pull && !holding && !movePlat)
        {
            if (hit.transform.gameObject.GetComponent("TelikineticObject"))
            {
                hit.transform.GetComponent<Renderer>().material = Resources.Load("outlineMat", typeof(Material)) as Material;
                objectList.Add(hit.transform);
                moveTarget = hit.transform.gameObject;
                
                if (moveTarget.GetComponent<TelikineticObject>().isPlatform)
                {
                    if (Input.GetKey(KeyCode.Mouse0))
                    {
                        movePlat = true;
                        player.GetComponent<CharacterMotor>().enabled = false;
                    }
                }
             
                else
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        currentLerpTime = 0f;
                        pull = true;
                        startPos = hit.transform;
                    }
                }
            }
        }

        if(movePlat)
        {
            if(!Input.GetKey(KeyCode.Mouse0))
            {
                player.GetComponent<CharacterMotor>().enabled = true;
                movePlat = false;
            }

            if (Input.GetKey(KeyCode.W))
            {
                player.GetComponent<CharacterMotor>().enabled = false;
                moveTarget.transform.position = moveTarget.transform.position - new Vector3(0, 0, 0.1f);
            }

            else if (Input.GetKey(KeyCode.S))
            {
                moveTarget.transform.position = moveTarget.transform.position + new Vector3(0, 0, 0.1f);
            }

            else if (Input.GetKey(KeyCode.A))
            {
                moveTarget.transform.position = moveTarget.transform.position + new Vector3(0.1f, 0, 0);
            }

            else if (Input.GetKey(KeyCode.D))
            {
                moveTarget.transform.position = moveTarget.transform.position - new Vector3(0.1f, 0, 0);
            }
        }

        if(pull)
        {
            perc = currentLerpTime / lerpTime;
            moveTarget.transform.position = Vector3.Lerp(startPos.position, cam.position + cam.forward * 3, perc);
            if(currentLerpTime >= lerpTime)
            {
                pull = false;
                holding = true;
            }
        }

        if(holding)
        {
            moveTarget.transform.position = cam.position + cam.forward * 3;
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                holding = false;
                moveTarget.transform.position = cam.position + cam.forward * 3 + Vector3.up * 1;
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                holding = false;
                moveTarget.GetComponent<Rigidbody>().AddForce((cam.forward + Vector3.up).normalized * 2500);
            }
            
            if (moveTarget.GetComponent<TelikineticObject>().isColliding)
            {
                holding = false;
            }
        }
	}
}
