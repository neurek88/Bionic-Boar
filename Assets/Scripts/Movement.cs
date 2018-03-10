using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameObject Tigger;
    public GameObject OtherPrefab;

    public Rigidbody2D SaucerPig;
    public Rigidbody2D ZombiePig;
    public Rigidbody2D PlantCrawler;

    public GameObject Player;

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D Trigger)
    {
        if (Trigger.tag == "Player") {
            OtherPrefab.transform.position = new Vector3(transform.position.x + 14.71f, transform.position.y);
            Debug.Log(transform.position.x);
            if (transform.position.x > 15)
            {
                Vector3 saucerPostion = new Vector3(transform.position.x + 11f, transform.position.y + .2f);
                Rigidbody2D saucerClone = Instantiate(SaucerPig, saucerPostion, Quaternion.identity);
                Vector3 ZombiePostion = new Vector3(transform.position.x + 13f, transform.position.y - .4f);
                Rigidbody2D ZombieClone = Instantiate(ZombiePig, ZombiePostion, Quaternion.identity);
                ZombieEnemyDeath.movementSpeed = -.3f;
            }
            if (transform.position.x > 35)
            {
                CloneEnemy(13.5f, .6f, 14.5f, 16f);
            }
            if (transform.position.x > 60)
            {
                Vector3 saucerPostion2 = new Vector3(transform.position.x + 14.5f, transform.position.y + .4f);
                Rigidbody2D saucerClone2 = Instantiate(SaucerPig, saucerPostion2, Quaternion.identity);
                Vector3 ZombiePostion2 = new Vector3(transform.position.x + 15.5f, transform.position.y - .4f);
                Rigidbody2D ZombieClone2 = Instantiate(ZombiePig, ZombiePostion2, Quaternion.identity);
            }
         /*   if (transform.position.x > 100)
            {
                CloneEnemy(16f, 1.1f, 17f, 14f);
                ZombieEnemyDeath.movementSpeed = -.5f;
            }
            if (transform.position.x > 160)
            {
                CloneEnemy(18f, .7f, 20f, -20f);
                ZombieEnemyDeath.movementSpeed = -.7f;
            }
            if (transform.position.x > 200)
            {
                CloneEnemy(19f, .5f, 22f, -10f);
                ZombieEnemyDeath.movementSpeed = -1f;
            }
            if (transform.position.x > 240)
            {
                CloneEnemy(21f, .6f, 24f, 22f);
                ZombieEnemyDeath.movementSpeed = -1.5f;
            }
            if (transform.position.x > 280)
            {
                CloneEnemy(23f, 1f, 27f, 24f);
                ZombieEnemyDeath.movementSpeed = -2.5f;
            }
            if (transform.position.x > 350)
            {
                CloneEnemy(26f, .8f, 28f, -23f);
                ZombieEnemyDeath.movementSpeed = -5f;
            }
            if (transform.position.x > 500)
            {
                CloneEnemy(30f, 1.2f, 30f, 29f);
                ZombieEnemyDeath.movementSpeed = -10f;
            }
            */
        }
    }
    public void CloneEnemy (float saucerPostion, float saucerHeight, float ZombiePostion, float plantPostion)
    {
        Vector3 saucerPostion2 = new Vector3(transform.position.x + saucerPostion, transform.position.y + saucerHeight);
        Rigidbody2D saucerClone2 = Instantiate(SaucerPig, saucerPostion2, Quaternion.identity);
        Vector3 ZombiePostion2 = new Vector3(transform.position.x + ZombiePostion, transform.position.y - .4f);
        Rigidbody2D ZombieClone2 = Instantiate(ZombiePig, ZombiePostion2, Quaternion.identity);
        Vector3 plantPostion2 = new Vector3(transform.position.x + ZombiePostion, transform.position.y - .8f);
        Rigidbody2D PlantClone = Instantiate(PlantCrawler, plantPostion2, Quaternion.identity);
    }
}
