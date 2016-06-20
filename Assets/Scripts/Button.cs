using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public bool pressed;
    GameObject cube;

    // Use this for initialization
    void Start () {
        pressed = false;
        if (this.name == "TriggerCube")
        {
            cube = GameObject.Find("ZoneInCube");
            cube.SetActive(false);
        }
        else cube = this.gameObject;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<TelikineticObject>())
        {
            pressed = true;
            if(this.gameObject.tag == "WallButton")
            {
                this.GetComponent<Renderer>().enabled = false;
                if(this.name == "TriggerCube")
                {
                    cube.SetActive(true);
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<TelikineticObject>())
        {
            if (this.gameObject.tag != "WallButton")
            {
                pressed = false;
            }
        }
    }
}
