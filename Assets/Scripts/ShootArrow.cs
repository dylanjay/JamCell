using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootArrow : MonoBehaviour {

    public GameObject arrow;
    public float arrowTime;
    public float arrowInterval;
    public bool on;
    List<GameObject>arrows;
    int arrowCount;

    // Use this for initialization
    void Start()
    {
        arrowTime = 0.0f;
        arrowInterval = 3.0f;
        arrow.GetComponent<ArrowMove>().dir = this.transform.forward;
        on = true;
        arrows = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            arrows.Add((GameObject)Instantiate(arrow, this.transform.position - 10 * this.transform.forward, Quaternion.Euler(90, 0, 0)));
            if(this.transform.parent.transform.parent.name =="ShooterArray")
            {
                arrows[i].AddComponent<KillOnHit>();
            }
        }
        arrowCount = 0;
    }
	// Update is called once per frame
	void Update () {
	    if(arrowTime < arrowInterval)
        {
            arrowTime += Time.deltaTime;
        }

        else
        {
            arrowTime = 0.0f;
            if (on)
            {
                //Instantiate(arrow, this.transform.position, Quaternion.Euler(90, 0, 0));
                if(arrowCount == 10)
                {
                    arrowCount = 0;
                }
                arrows[arrowCount].GetComponent<ArrowMove>().on = true;
                arrows[arrowCount].transform.position = this.transform.position;
                arrowCount++;
            }
            else
            {
                this.transform.parent.transform.parent.GetComponent<RandArrow>().go = true;
            }
        }

        if(arrows[0].GetComponent<ArrowMove>().speed < 20)
        {
            for (int i = 0; i < 10; i++)
            {
                arrows[i].GetComponent<ArrowMove>().speed = 20.0f;
            }
        }
	}
}
