using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrail : MonoBehaviour {

    public int MoveSpeed = 230;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right* Time.deltaTime* MoveSpeed);
        Destroy(this.gameObject,100);
	}
}
