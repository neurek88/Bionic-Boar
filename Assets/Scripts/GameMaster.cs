using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
    public class GameMaster : MonoBehaviour
    {



        public static GameMaster gm;

        public static void KillPlayer(GameObject player)
        {
            Destroy(player.gameObject);
        }

        // Use this for initialization
        void Awake()
        {
            if (gm == null)
            {
                gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameMaster>();
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }