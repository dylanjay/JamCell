using UnityEngine;
using System.Collections;

public class ShootArrow : MonoBehaviour {

    public GameObject arrow;
    float arrowTime;
    float arrowInterval;

	// Use this for initialization
	void Start () {
        arrowTime = 0.0f;
        arrowInterval = 4.0f;
        arrow.GetComponent<ArrowMove>().dir = this.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
	    if(arrowTime < arrowInterval)
        {
            arrowTime += Time.deltaTime;
        }

        else
        {
            arrowTime = 0.0f;
            Instantiate(arrow, this.transform.position, Quaternion.Euler(90,0,0));
        }
	}
}
