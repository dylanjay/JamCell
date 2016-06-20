using UnityEngine;
using System.Collections;

public class ButtonCheck : MonoBehaviour {

    public GameObject door;
    GameObject blueKey;

	// Use this for initialization
	void Start () {
        //door.SetActive(false);
        if (this.name == "TeleButtons")
        {
            blueKey = GameObject.Find("BlueKey");
            //blueKey.SetActive(false);
        }
        else
        {
            door.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(checkArray())
        {
            if (this.name == "TeleButtons")
            {
                blueKey.SetActive(true);
            }
            else
            {
                door.SetActive(true);
            }
        }

        else
        {
            if (this.name == "TeleButtons")
            {
                blueKey.SetActive(false);
            }
            else
            {
                    door.SetActive(false);
            }
        }
	}

    bool checkArray()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if(!this.transform.GetChild(i).GetComponent<Button>().pressed)
            {
                return false;
            }
        }
        return true;
    }
}
