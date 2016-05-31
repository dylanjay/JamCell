using UnityEngine;
using System.Collections;

public class TelikineticObject : MonoBehaviour {

    public bool isColliding;

	// Use this for initialization
	void Start () {
        isColliding = false;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(isColliding);
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
