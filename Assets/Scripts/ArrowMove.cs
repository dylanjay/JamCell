using UnityEngine;
using System.Collections;

public class ArrowMove : MonoBehaviour {

    float speed;
    public Vector3 dir;

	// Use this for initialization
	void Start () {
        speed = 5.0f;
        //forward = new Vector3(this.transform.forward.z, this.transform.forward.y, this.transform.forward.x);
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position += speed * dir * Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "ArrowWall")
        {
            Destroy(this.gameObject);
        }
    }
}
