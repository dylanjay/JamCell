using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public Transform respawn;
    public bool hit;
    GameObject upperFloor;
    GameObject redKey;
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
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    { 
        if(other.tag == "Arrow")
        {
            Destroy(other.gameObject);
            hit = true;
        }

        if (other.name == "EndPlatCollide")
        {
            upperFloor.SetActive(true);
            redKey.transform.GetChild(0).GetComponent<Renderer>().enabled = true;
            redKey.GetComponent<Renderer>().enabled = true;
        }
    }
}
