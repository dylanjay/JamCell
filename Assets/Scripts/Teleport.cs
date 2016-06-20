using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    GameObject redDoor;
    GameObject blueDoor;
    GameObject greenDoor;

    // Use this for initialization
    void Start () {
        redDoor = GameObject.Find("Grapple1");
        greenDoor = GameObject.Find("Time1");
        blueDoor = GameObject.Find("Telekinesis1");
    }
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter(Collider other)
    { 
        GameObject player = GameObject.Find("Player");
        if (other.gameObject == player)
        {
            player.transform.position = this.gameObject.transform.GetChild(0).transform.position;
            player.GetComponent<Respawn>().respawn = this.gameObject.transform.GetChild(0).transform;
            switch (this.gameObject.transform.GetChild(0).name)
            {
                case "TelekinesisStart":
                    player.transform.GetChild(1).GetComponent<Telekinesis>().enabled = true;
                    break;

                case "GrappleStart":
                    player.transform.GetChild(1).GetComponent<Grapple>().enabled = true;
                    break;

                case "SlowStart":
                    player.transform.GetChild(1).GetComponent<SlowTime>().enabled = true;
                    break;

                case "DoorRoom":
                    player.transform.GetChild(1).GetComponent<Telekinesis>().enabled = false;
                    player.transform.GetChild(1).GetComponent<Grapple>().enabled = false;
                    player.transform.GetChild(1).GetComponent<SlowTime>().enabled = false;
                    break;

                case "GrappleEnd":
                    GameObject plat = GameObject.Find("DemoPlat");
                    plat.GetComponent<TransparentPlatform>().lerp = true;
                    break;

                case "Time3Start":
                    GameObject plat2 = GameObject.Find("DemoPlat2");
                    plat2.GetComponent<TransparentPlatform>().lerp = true;
                    break;

                case "RedEnd":
                    redDoor.SetActive(false);
                    break;

                case "GreenEnd":
                    greenDoor.SetActive(false);
                    break;

                case "BlueEnd":
                    blueDoor.SetActive(false);
                    break;
            }
        }
    }
}
