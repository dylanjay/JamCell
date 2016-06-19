using UnityEngine;
using System.Collections;

public class Crush : MonoBehaviour {

    Vector3 dir;
    float crushInterval;
    float crushTimer;
    float speed;
    public bool retract;
    Vector3 curPos;

	// Use this for initialization
	void Start () {
        dir = this.transform.GetChild(2).transform.position - this.transform.GetChild(0).transform.position;
        crushInterval = 0.25f;
        crushTimer = 0.0f;
        speed = 10f;
        retract = false;
        curPos = this.transform.GetChild(3).transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        crushTimer += Time.deltaTime;

        if (retract)
        {
            this.transform.GetChild(1).transform.position -= speed * dir * Time.deltaTime;
            this.transform.GetChild(2).transform.position -= speed * dir * Time.deltaTime;
            this.transform.GetChild(3).transform.position -= speed * dir * Time.deltaTime;
            if (this.transform.GetChild(3).transform.position.y >= curPos.y)
            {
                retract = false;
            }
            crushTimer = 0.0f;
        }

        else if (crushTimer >= crushInterval)
        {
            this.transform.GetChild(1).transform.position += speed * dir * Time.deltaTime;
            this.transform.GetChild(2).transform.position += speed * dir * Time.deltaTime;
            this.transform.GetChild(3).transform.position += speed * dir * Time.deltaTime;
        }

        /*else if(crushTimer >= crushInterval)
        {

        }*/
	}
}
