using UnityEngine;
using System.Collections;

public class SlowTime : MonoBehaviour {

    float speed;
    GameObject player;
    Transform cam;
    public bool death;
    public Texture tex;

    float barHeight;
    float barLength;

    float perc;
    float rate;

	// Use this for initialization
	void Start () {
        speed = 2.0f;
        player = GameObject.Find("Player");
        cam = this.transform;
        barHeight = 20;
        barLength = 800;
        perc = 0;
        rate = 0.8f;
    }
	
	// Update is called once per frame
	void Update () {

        if (!death)
        {
            if (Input.GetKey(KeyCode.Mouse0) && perc < 1.0f)
            {
                perc += rate * Time.deltaTime;
                player.GetComponent<CharacterMotor>().canControl = false;
                Time.timeScale = 0.5f;
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
                player.GetComponent<CharacterMotor>().canControl = true;
                Time.timeScale = 1.0f;

                if(perc > 0.0f && !Input.GetKey(KeyCode.Mouse0))
                {
                    perc -= rate * Time.deltaTime / 3;
                }
            }
        }
    }

    void OnGUI()
    {
        Texture2D MyTexture = Resources.Load("white") as Texture2D;
        GUI.color = new Color(0, 1.0f, 0);//Set color to red
        GUI.DrawTexture(new Rect(50, 50, barHeight, barLength * perc), MyTexture);
        GUI.color = Color.white;//Reset color to white
    }
}
