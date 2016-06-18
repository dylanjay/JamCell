using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour {

    float speed;
    GameObject player;
    Transform cam;

	// Use this for initialization
	void Start () {
        speed = 2.0f;
        player = GameObject.Find("Player");
        cam = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(cam.forward);
        if (Input.GetKey(KeyCode.Mouse0))
        {
            player.GetComponent<CharacterMotor>().enabled = false;
            Time.timeScale = 0.5f;
            //Vector3 right = Vector3.Cross(cam.forward.normalized, new Vector3(0.0f, 1.0f, 0.0f).normalized);
            //Vector3 left = -right;
            Vector3 forward = new Vector3(cam.forward.x, 0.0f, cam.forward.z).normalized;
            Vector3 backward = new Vector3(-cam.forward.x, 0.0f, -cam.forward.z).normalized;
            Vector3 left = new Vector3(-cam.forward.z, 0.0f, cam.forward.x).normalized;
            Vector3 right = new Vector3(cam.forward.z, 0.0f, -cam.forward.x).normalized;

            if (Input.GetKey(KeyCode.W))
            {
                player.transform.position += speed * Time.fixedDeltaTime * forward;
            }

            if (Input.GetKey(KeyCode.A))
            {
                player.transform.position += speed * Time.fixedDeltaTime * left;
            }

            if (Input.GetKey(KeyCode.S))
            {
                player.transform.position += speed * Time.fixedDeltaTime * backward;
            }

            if (Input.GetKey(KeyCode.D))
            {
                player.transform.position += speed * Time.fixedDeltaTime * right;
            }
        }

        else
        {
            player.GetComponent<CharacterMotor>().enabled = true;
            Time.timeScale = 1.0f;
        }
    }
}
