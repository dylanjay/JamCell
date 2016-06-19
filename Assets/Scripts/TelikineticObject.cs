using UnityEngine;
using System.Collections;

public class TelikineticObject : MonoBehaviour {

    public bool isColliding;
    public bool isPlatform;

	// Use this for initialization
	void Start () {
        isColliding = false;

        if(this.tag == "Platform")
        {
            isPlatform = true;
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision other)
    {
        isColliding = true;
    }

    void OnCollisionExit(Collision other)
    {
        isColliding = false;
    }
}
