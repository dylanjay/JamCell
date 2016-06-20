using UnityEngine;
using System.Collections;

public class KeyZone : MonoBehaviour {

    GameObject door;
    GameObject player;
    GameObject hole;
    GameObject blueDoor;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	    switch(this.name)
        {
            case "RedKey":
                door = GameObject.Find("Grapple5");
                hole = GameObject.Find("RedHole");
                break;

            case "BlueKey":
                door = GameObject.Find("Tele5");
                hole = GameObject.Find("BlueHole");
                break;

            case "GreenKey":
                door = GameObject.Find("Time4");
                hole = GameObject.Find("GreenHole");
                break;
        }
        door.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == player.name)
        {
            switch(this.name)
            {
                case "RedKey":
                    hole.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                    break;

                case "BlueKey":
                    hole.GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                    this.GetComponent<Renderer>().enabled = false;
                    break;

                case "GreenKey":
                    hole.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                    break;
            }
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            door.SetActive(true);
        }
    }
}
