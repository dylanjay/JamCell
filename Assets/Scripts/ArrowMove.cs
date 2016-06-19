using UnityEngine;
using System.Collections;

public class ArrowMove : MonoBehaviour {

    public float speed;
    public Vector3 dir;
    Vector3 start;
    public bool on;

	// Use this for initialization
	void Start () {
        speed = 5.0f;
        start = this.transform.position;
        on = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (on)
        {
            this.transform.position += speed * dir * Time.deltaTime;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "ArrowWall")
        {
            //Destroy(this.gameObject);
            on = false;
            this.transform.position = start;
        }
    }
}
