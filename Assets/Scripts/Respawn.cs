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
    //GameObject greenKey;

    // Use this for initialization
    void Start () {
        hit = false;
        upperFloor = GameObject.FindGameObjectWithTag("ZoneIn");
        upperFloor.SetActive(false);
        redKey = GameObject.Find("RedKey");
        redKey.transform.GetChild(0).GetComponent<Renderer>().enabled = false;
        redKey.GetComponent<Renderer>().enabled = false;
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

        if(other.name == "Time2Start" || other.name == "TimeStart")
        {
            this.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
