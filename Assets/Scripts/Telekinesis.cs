using UnityEngine;
using System.Collections;

public class Telekinesis : MonoBehaviour {

    float lerpTime;
    float currentLerpTime;
    bool pull;
    GameObject moveTarget;
    float perc;
    Transform startPos;
    bool holding;

    // Use this for initialization
	void Start () {
        lerpTime = 1f;
        currentLerpTime = 0f;
        pull = false;
        holding = false;
	}

	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Transform cam = this.transform;
      
        if (currentLerpTime <= lerpTime)
        {
            currentLerpTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            currentLerpTime = 0f;
            if(Physics.SphereCast(cam.position, 3, cam.forward, out hit, 500))
            {
                //Destroy(hit.transform.gameObject);
                GameObject target = hit.transform.gameObject;
                moveTarget = target;
                if(target.GetComponent("TelikineticObject"))
                {
                    pull = true;
                    startPos = hit.transform;
                }
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
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                holding = false;
                moveTarget.transform.position = cam.position + cam.forward * 3 + Vector3.up * 1;
            }

            if (moveTarget.GetComponent<TelikineticObject>().isColliding)
            {
                holding = false;
            }
        }
	}
}
