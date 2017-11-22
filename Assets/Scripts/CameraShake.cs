using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
    public Camera mainCam;

    float shakeAmount = 0;
	// Use this for initialization
	void Awake () {
		if (mainCam == null)
        {
            mainCam = Camera.main;
        }
	}
	
    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = mainCam.transform.position;
            float offestX = Random.value * shakeAmount * 2 - shakeAmount;
            float offestY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offestX;
            camPos.y += offestY;

            mainCam.transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        mainCam.transform.localPosition = Vector3.zero;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
