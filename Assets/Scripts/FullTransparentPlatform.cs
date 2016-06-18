using UnityEngine;
using System.Collections;

public class FullTransparentPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.GetChild(0).GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.GetChild(1).GetComponent<TransparentPlatform>().faded)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
	}
}
