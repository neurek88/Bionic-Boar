using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public GameObject Tigger;
    public GameObject OtherPrefab;

    // Use this for initialization
    void OnTriggerEnter2D(Collider2D Trigger)
    {
        OtherPrefab.transform.position = new Vector3(transform.position.x + 14.66f, transform.position.y - 0.0f);
    }
}
