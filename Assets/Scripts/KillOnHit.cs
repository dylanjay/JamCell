﻿using UnityEngine;
using System.Collections;

public class KillOnHit : MonoBehaviour {

    float deathTime;
    bool death;
    GameObject player;
    Vector3 startPos;
    float lerpTime;
    float currentLerpTime;
    Vector3 camDiff;
    GameObject lowerFloor;
    GameObject[] plats;
    GameObject[] hooks;

    // Use this for initialization
    void Start () {
        lerpTime = 2f;
        currentLerpTime = 0f;
        deathTime = 3.0f;
        death = false;
        player = GameObject.Find("Player");
        camDiff = player.transform.GetChild(1).transform.position - player.transform.position;
        lowerFloor = GameObject.Find("LowerFloor");
        plats = GameObject.FindGameObjectsWithTag("FadedPlatform");
        hooks = GameObject.FindGameObjectsWithTag("Hook");
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.F1))
        {
            player.transform.GetChild(1).transform.position = player.transform.position;
            player.transform.GetChild(1).transform.position += camDiff;
            player.transform.position = player.GetComponent<Respawn>().respawn.position;
            death = false;
            player.transform.GetChild(1).GetComponent<SlowTime>().death = false;
            player.GetComponent<Respawn>().death = false;
            deathTime = 3.0f;
            player.GetComponent<CharacterMotor>().enabled = true;
            player.GetComponent<CharacterMotor>().canControl = true;
            player.GetComponent<Respawn>().hit = false;

            foreach (GameObject plat in plats)
            {
                plat.SetActive(true);
                if (plat.GetComponent<TransparentPlatform>() != null)
                {
                    plat.GetComponent<TransparentPlatform>().faded = false;
                }
            }

            foreach (GameObject hook in hooks)
            {
                hook.SetActive(true);
            }
            lowerFloor.SetActive(true);
        }

        if (currentLerpTime <= lerpTime)
        {
            currentLerpTime += Time.fixedDeltaTime;
        }

        if (death)
        {
            deathTime -= Time.fixedDeltaTime;
            player.transform.GetChild(1).transform.position = Vector3.Lerp(startPos, startPos - new Vector3(0, 1.0f, 0), currentLerpTime / lerpTime);
        }
        
        if (deathTime <= 0.0f && Input.GetKey(KeyCode.Mouse0))
        {
            player.transform.GetChild(1).transform.position = player.transform.position;
            player.transform.GetChild(1).transform.position += camDiff;
            player.transform.position = player.GetComponent<Respawn>().respawn.position;
            death = false;
            player.transform.GetChild(1).GetComponent<SlowTime>().death = false;
            player.GetComponent<Respawn>().death = false;
            deathTime = 3.0f;
            player.GetComponent<CharacterMotor>().enabled = true;
            player.GetComponent<CharacterMotor>().canControl = true;
            player.GetComponent<Respawn>().hit = false;
 
            foreach(GameObject plat in plats)
            {
                plat.SetActive(true);
                if (plat.GetComponent<TransparentPlatform>() != null)
                {
                    plat.GetComponent<TransparentPlatform>().faded = false;
                }
            }

            foreach (GameObject hook in hooks)
            {
                hook.SetActive(true);
            }
            lowerFloor.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            player.GetComponent<CharacterMotor>().enabled = false;
            player.transform.GetChild(1).GetComponent<SlowTime>().death = true;
            if (!death)
            {
                startPos = player.transform.GetChild(1).transform.position;
                currentLerpTime = 0f;
            }
            if (!player.GetComponent<Respawn>().death)
            {
                death = true;
            }
            player.GetComponent<Respawn>().death = true;
        }
    }
}
