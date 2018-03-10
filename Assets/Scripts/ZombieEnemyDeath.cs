using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemyDeath : MonoBehaviour
{

    public int Damage;
    public static float movementSpeed = -.2f;
    public Rigidbody2D zombie;

    /* Update is called once per frame
    void OnCollisionEnter2D()
    {
        Damage += 10;
        Debug.Log("Zombie Hit!");
       if (Damage > 20)
        {
            Destroy(gameObject);
            Debug.Log("Zombie Pig Killed");
        } 
         
    }
    */

    void FixedUpdate()
    {

        //if died that 
        zombie.velocity = new Vector2(movementSpeed, zombie.velocity.y);
        //else
        //moving

    }
}