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

    public bool jump = false;               // Condition for whether the player should jump.	
    public float jumpForce = 10f;            // Amount of force added when the player jumps.
    private bool grounded = false;          // Whether or not the player is grounded.
    public Vector3 jumping;
    public Rigidbody2D player;// The animator that controls the characters animations


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
        if (jump == true)
        {
            // Add a vertical force to the player.
            player.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            Debug.Log("time to Jump");
            // We set the variable to false again to avoid adding force constantly
            jump = false;
        }
    }
    void Shoot()
    {
        Vector2 mousePostion = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, (mousePostion - firePointPosition), 6, WhatToHit);

        if (Time.time >= timeToSpawnEffect)
        {
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
        }
        Debug.DrawLine(firePointPosition, (mousePostion - firePointPosition) * 100, Color.cyan);
        if (hit.collider != null)
        {
            grounded = true;
            
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            Debug.Log("We hit" + hit.collider.name + " and did " + Damage + "damage");
            if (hit.collider.tag == "enemy")
            {
                Destroy(hit.collider.gameObject);
                Debug.Log("why won't you die");
            }
            //The update method is called many times per seconds
            if (hit.collider.tag == "Jump")
            {
                // If the jump button is pressed and the player is grounded and the character is running forward then the player should jump.
                if (grounded == true)
                {
                    jump = true;
                    grounded = false;
                    player.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    Debug.Log("jumpman");
                }
                

            }
        }
    }
    void Effect ()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.rotation);

        //shake camera
        //camShake.Shake(camShakeAmt, camShakeLength);
    }
}
