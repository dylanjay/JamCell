using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Grapple : MonoBehaviour {
    GameObject player;
    float speed;
    List<Transform> objectList;
    Material diffuse;
    bool hold;
    Vector3 target;
    GameObject cur;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        speed = 3.0f;
        hold = false;
        objectList = new List<Transform>();

        GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Plane);
        primitive.SetActive(false);
        diffuse = primitive.GetComponent<MeshRenderer>().sharedMaterial;
        DestroyImmediate(primitive);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Transform cam = this.transform;

        for (int i = 0; i < objectList.Count; i++)
        {
            objectList[i].GetComponent<Renderer>().material = diffuse;
        }
        objectList.Clear();

        if(player.GetComponent<Respawn>().hit)
        {
            hold = false;
            player.GetComponent<CharacterMotor>().canControl = false;
            player.GetComponent<CharacterMotor>().enabled = true;
        }

        else
        {

            if (Physics.SphereCast(cam.position - cam.forward * 1, 1, cam.forward, out hit, 20))
            {
                if (hit.transform.tag == "Hook")
                {
                    hit.transform.GetComponent<Renderer>().material = Resources.Load("outlineMat", typeof(Material)) as Material;
                    objectList.Add(hit.transform);

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        if (hold)
                        {
                            cur.SetActive(false);
                        }
                        else
                        {
                            hold = true;
                        }
                        target = hit.transform.position;
                        cur = hit.transform.gameObject;
                        player.GetComponent<CharacterMotor>().enabled = false;
                    }
                }
            }

            if (hold)
            {
                Vector3 offset = target - player.transform.position;
                if (offset.magnitude > 1.5f)
                {
                    player.transform.position = Vector3.MoveTowards(player.transform.position, target, speed * Time.fixedDeltaTime);
                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    hold = false;
                    player.GetComponent<CharacterMotor>().enabled = true;

                    cur.SetActive(false);
                }
            }
        }
    }
}
