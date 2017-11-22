using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//This scrits makes the character move when the screen is pressed and handles the jump
public class CharacterFinal : MonoBehaviour
{
	public bool jump = false;				// Condition for whether the player should jump.	
	public float jumpForce = 10.0f;			// Amount of force added when the player jumps.
	private bool grounded = false;			// Whether or not the player is grounded.
	public float movementSpeed = 5f;			// The vertical speed of the movement
	private Animator anim;
    public Rigidbody2D player;// The animator that controls the characters animations
    public GameObject zombie;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}
	

	//This method is called when the character collides with a collider (could be a platform).
	void OnCollisionEnter2D(Collision2D hit)
	{
		grounded = true;
		print ("isground");
        var gameMast = GameObject.Find("GameMaster");
        if (hit.gameObject.tag == "Enemy")
        {
            GameMaster.KillPlayer(this.gameObject);
        }
	}

	//The update method is called many times per seconds
	void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{		
			// If the jump button is pressed and the player is grounded and the character is running forward then the player should jump.
			if(grounded == true)						
			{
				jump = true;
				grounded = false;
				//We trigger the Jump animation state
				anim.SetTrigger("Jump");
			}
		
		}

	}



	//Since we are using physics for movement, we use the FixedUpdate method
	void FixedUpdate ()
	{

		//if died that 
		player.velocity = new Vector2(movementSpeed, player.velocity.y );
		//else
		//moving
	
	}
}
