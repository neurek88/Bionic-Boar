using UnityEngine;
using System.Collections;

public class died : MonoBehaviour {

	public GameObject endmenu;
	public GameObject ingameDisplay;

    void update ()
    {


        if (transform.position.y < -1)
        {
            Destroy(this.gameObject);
            endmenu.SetActive(true);
            ingameDisplay.SetActive(false);
        }
        Debug.Log(transform.position.x);   
    }
	/*void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
            endmenu.SetActive(true);
            ingamedisplay.SetActive(false);
        }

    }*/
}
