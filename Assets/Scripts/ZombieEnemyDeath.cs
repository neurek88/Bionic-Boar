using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieEnemyDeath : MonoBehaviour
{

    public int Damage;
   

    // Update is called once per frame
    void OnCollisionEnter2D()
    {
        Damage += 10;
        Debug.Log("Zombie Hit!");
       if (Damage > 50)
        {
            Destroy(gameObject);
            Debug.Log("Zombie Pig Killed");
        } 
         
    }
}