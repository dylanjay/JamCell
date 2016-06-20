using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public Transform respawn;
    public bool hit;
    public bool death;
    GameObject upperFloor;
    GameObject redKey;
    GameObject[] arrows;
    //GameObject blueKey;
    GameObject greenKey;
    //BoxCollider timeEnd;

    // Use this for initialization
    void Start () {
        respawn = this.transform;
        hit = false;
        upperFloor = GameObject.FindGameObjectWithTag("ZoneIn");
        //timeEnd = GameObject.Find("Time4").transform.GetChild(3).GetComponent<BoxCollider>();
        //timeEnd.isTrigger = false;
        upperFloor.SetActive(false);
        redKey = GameObject.Find("RedKey");
        redKey.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        redKey.GetComponent<Renderer>().enabled = false;
        greenKey = GameObject.Find("GreenKey");
        greenKey.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        greenKey.GetComponent<Renderer>().enabled = false;
        arrows = GameObject.FindGameObjectsWithTag("ArrowShooter");
        death = false;
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    { 
        if(other.tag == "Arrow")
        {
            //Destroy(other.gameObject);
            hit = true;
        }

        if (other.name == "EndPlatCollide")
        {
            upperFloor.SetActive(true);
            redKey.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            redKey.GetComponent<Renderer>().enabled = true;
        }

        if(other.name == "endTimeCollide")
        {
            greenKey.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            greenKey.GetComponent<Renderer>().enabled = true;
            //timeEnd.isTrigger = true;
        }

        /*if(other.name == "ArrowWall")
        {
            foreach (GameObject arrow in arrows)
            {
                arrow.GetComponent<ShootArrow>().on = true;
            }
        }*/

        if(other.name == "StopArrows")
        {
            foreach (GameObject arrow in arrows)
            {
                arrow.GetComponent<ShootArrow>().on = false;
            }
        }

        if(other.name == "Time2Start" || other.name == "TimeStart" || other.name == "Time3Start" || other.name == "start")
        {
            this.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
