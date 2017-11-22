using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour {

    public float FireRate = 0;
    public float Damage = 10;
    public LayerMask WhatToHit;

    public Transform BulletTrailPrefab;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;
    public Animator GunAnimation;
    public float camShakeAmt = 0.02f;
    public float camShakeLength = 0.02f;
    CameraShake camShake;
    

    float timeToFire = 0; 
    Transform firePoint;

    // Use this for initialization
    void Awake() {
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.LogError("can't find firepoint");
        }
    }

    void Start() { 
    camShake = GameMaster.gm.GetComponent<CameraShake>();
        if (camShake == null)
        {
            Debug.Log("no shaking can happen");
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        if (FireRate == 0)
        {
            if (Input.GetButtonDown ("Fire1"))
            {
                GunAnimation.SetBool("firing",true);
                Shoot();
                
            }
            else
            {
                GunAnimation.SetBool("firing", false);
            }
        }
        else
        {
            if (Input.GetButtonDown("Fire1") && Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / FireRate;
                GunAnimation.SetBool("firing", true);
                Shoot();
            }
            else
            {
                GunAnimation.SetBool("firing", false);
            }
        }
	}
    void Shoot ()
    {
        Vector2 mousePostion = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, (mousePostion-firePointPosition), 50, WhatToHit);
       
        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        Debug.DrawLine(firePointPosition, (mousePostion - firePointPosition) * 100, Color.cyan);
        if (hit.collider !=null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit" + hit.collider.name + " and did " + Damage + "damage");
        }
    }
    void Effect ()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);

        //shake camera
        //camShake.Shake(camShakeAmt, camShakeLength);
    }
}
