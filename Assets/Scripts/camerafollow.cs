using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {

	public GameObject character;
        public GameObject camerafollowobject;

	// Update is called once per frame
	void Update () {

		if (character.transform.position.x+6 > camerafollowobject.transform.position.x)
		{
			transform.position= new Vector3(character.transform.position.x+6.5f,camerafollowobject.transform.position.y,camerafollowobject.transform.position.z);
		}
	
	}
}
