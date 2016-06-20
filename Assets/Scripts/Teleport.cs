using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    GameObject redDoor;
    GameObject blueDoor;
    GameObject greenDoor;
    GameObject whiteDoor;
    GameObject text;

    // Use this for initialization
    void Start () {
        redDoor = GameObject.Find("Grapple1");
        greenDoor = GameObject.Find("Time1");
        blueDoor = GameObject.Find("Telekinesis1");
        whiteDoor = GameObject.Find("Final1");
        text = GameObject.Find("GameOverText");
        text.GetComponent<Renderer>().enabled = false;
        for (int i = 0; i < 3; i++)
        {
            whiteDoor.transform.GetChild(i).GetComponent<Renderer>().enabled = false;
        }
        whiteDoor.transform.GetChild(3).gameObject.SetActive(false);
        whiteDoor.transform.GetChild(4).gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        /*redDoor.SetActive(false);
        greenDoor.SetActive(false);
        blueDoor.SetActive(false);*/
        if (redDoor != null && blueDoor != null && greenDoor != null && whiteDoor != null)
        {
            if (!redDoor.activeSelf && !greenDoor.activeSelf && !blueDoor.activeSelf && !whiteDoor.transform.GetChild(0).GetComponent<Renderer>().enabled)
            {
                for (int i = 0; i < 3; i++)
                {
                    whiteDoor.transform.GetChild(i).GetComponent<Renderer>().enabled = true;
                }
                whiteDoor.transform.GetChild(3).gameObject.SetActive(true);
                whiteDoor.transform.GetChild(4).gameObject.SetActive(true);
            }
        }
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
                    Debug.Log(greenDoor.name);
                    greenDoor.SetActive(false);
                    break;

                case "BlueEnd":
                    blueDoor.SetActive(false);
                    break;
            }
            if(this.name == "FinalCollide")
            {
                text = GameObject.Find("GameOverText");
                text.GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
