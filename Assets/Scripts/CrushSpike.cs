using UnityEngine;
using System.Collections;

public class CrushSpike : MonoBehaviour {

    GameObject whole;

	// Use this for initialization
	void Start () {
        whole = transform.parent.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != LayerMask.NameToLayer("Ignore Collision"))
        {
            whole.GetComponent<Crush>().retract = true;
        }
    }
}
