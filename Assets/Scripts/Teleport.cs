using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    // Use this for initialization
    void Start () {
     
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider playerCollider)
    {
        GameObject player = GameObject.Find("Player");
        player.transform.position = this.gameObject.transform.GetChild(0).transform.position;
    }
}
