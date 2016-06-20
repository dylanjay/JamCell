using UnityEngine;
using System.Collections;

public class TelikineticObject : MonoBehaviour {

    public bool isColliding;
    public bool isPlatform;
    public bool southWall;
    public bool eastWall;
    public bool westWall;
    public bool northWall;
    bool otherTele;
    GameObject tele;
    Vector3 diff;

	// Use this for initialization
	void Start () {
        isColliding = false;

        if(this.tag == "Platform")
        {
            isPlatform = true;
        }
        southWall = westWall = northWall = eastWall = false;
        otherTele = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(otherTele)
        {
            tele.transform.position = this.transform.position + diff;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        isColliding = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TelikineticObject>() && isPlatform)
        {
            otherTele = true;
            tele = other.gameObject;
            diff = tele.transform.position - this.transform.position;
        }
        switch (other.gameObject.tag)
        {
            case "NorthWall":
                northWall = true;
                break;

            case "SouthWall":
                southWall = true;
                break;

            case "EastWall":
                eastWall = true;
                break;

            case "WestWall":
                westWall = true;
                break;
        }
    }

    void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TelikineticObject>() && isPlatform)
        {
            otherTele = false;
        }
        switch (other.gameObject.tag)
        {
            case "NorthWall":
                northWall = false;
                break;

            case "SouthWall":
                southWall = false;
                break;

            case "EastWall":
                eastWall = false;
                break;

            case "WestWall":
                westWall = false;
                break;
        }
    }
}
