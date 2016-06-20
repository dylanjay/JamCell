using UnityEngine;
using System.Collections;

public class TransparentPlatform : MonoBehaviour {

    GameObject player;
    public bool lerp;
    float fadePerSec;
    public bool faded;
    GameObject nextHook;
    public bool moving;
    bool dir;
    public float speed;
    public Vector3 axis;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        lerp = false;
        faded = false;
        fadePerSec = 0.3f;
        nextHook = GameObject.Find("NextHook");
        nextHook.GetComponent<Renderer>().enabled = false;
        dir = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (lerp)
        {
            Material material = transform.GetComponent<Renderer>().material;
            Color color = material.color;

            transform.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSec * Time.fixedDeltaTime));
            if(color.a <= 0.0f)
            {
                lerp = false;
                this.gameObject.SetActive(false);
                faded = true;
                transform.GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 1.0f);
            }
        }

        if(moving)
        {
            if (dir)
            {
                transform.position += axis * speed * Time.deltaTime;
            }
            else
            {
                transform.position -= axis * speed * Time.deltaTime;
            }
            this.transform.parent.GetChild(0).transform.position = this.transform.position;
        }

	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == player.name)
        {
            lerp = true;
        }

        if(this.name == "StarterPlat")
        {
            GameObject.Find("LowerFloor").SetActive(false);
            nextHook.GetComponent<Renderer>().enabled = true;
        }

        if(other.name == "WallRight" || other.name == "WallLeft" || other.name == "Floor" || other.name == "Ceiling" || other.name == "endCube" || other.name == "endPlatform")
        {
            //if(other.name == "endCube")
            //Debug.Log(other.name);
            dir = !dir;
        }
    }
}
