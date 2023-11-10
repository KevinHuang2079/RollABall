using System;
using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Create public variables for player speed, and for the Text UI game objects
	public float speed;

	// Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
	private Rigidbody rb;
	private int count;
	private GameController gameController;
	public STICKY stickyManager;
	public WallDetector wallDetector;
	private Vector3 spawnPoint;
	
	

	
	// At the start of the game..
	void Start ()
	{
		gameController = GetComponentInParent<GameController>();
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Set the count to zero 
		spawnPoint = rb.transform.position;
		count = 0;
	}
	

	// Each physics step..
	void FixedUpdate ()
	{
		if ( wallDetector.detectWall() == 1 && wallDetector.isWallCollision && stickyManager.isSticky )
		{
			stickyManager.stickLeftMovement();
			rb.useGravity = false;
		}
		else if ( wallDetector.detectWall() == 2 && wallDetector.isWallCollision && stickyManager.isSticky)
		{
			stickyManager.stickRightMovement();
			rb.useGravity = false;
		}
		else if ( wallDetector.detectWall() == 3 && wallDetector.isWallCollision && stickyManager.isSticky)
		{
			stickyManager.stickForwardMovement();
			rb.useGravity = false;
		}
		else if ( wallDetector.detectWall() == 4 && wallDetector.isWallCollision && stickyManager.isSticky)
		{
			stickyManager.stickBackMovement();
			rb.useGravity = false;
		}
		else if ( wallDetector.detectWall() == 0 ) 
		{ 
			// Debug.Log("groundMovement");
			groundMovement();
			rb.useGravity = true;
		}
		else
		{
			groundMovement();
		}
		
		
		
	}

	// When this game object intersects a collider with 'is trigger' checked, 
	// store a reference to that collider in a variable named 'other'..
	void OnTriggerEnter(Collider other) 
	{
		// ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			// Make the other game object (the pick up) inactive, to make it disappear
			other.gameObject.SetActive (false);

			// Add one to the score variable 'count'
			count = count + 1;

			// Run the GameController function for picking up a collectible
			gameController.OnPickUpCollectible(count);
		}
		if (other.gameObject.CompareTag("STICKY"))
		{
			stickyManager.itsStickyTime();
			other.gameObject.SetActive(false);
		}
	}

	private void groundMovement()
	{
		// Set some local float variables equal to the value of our Horizontal and Vertical Inputs
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
		// multiplying it by 'speed' - our public player speed that appears in the inspector
		rb.AddForce (movement * speed);
	}
	
	public void onDeathActivate()
	{
		rb.transform.position = spawnPoint;
	}
	
	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Death"))
		{
			onDeathActivate();
		}
       
	}
	
	
	
	
}