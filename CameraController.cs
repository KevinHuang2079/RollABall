using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// store a public reference to the Player game object, so we can refer to it's Transform
	public GameObject player;
	public STICKY stickyManager;
	// Store a Vector3 offset from the player (a distance to place the camera from the player at all times)
	private Vector3 defaultOffset;
	public WallDetector wallDetector;
	public float cameraLerpSpeed = 5.0f;

	public PlayerController playerController;
	private bool hasAdjustedOffset;
	private Vector3 adjustableOffset;
	
	// At the start of the game..
	void Start ()
	{
		// Create an offset by subtracting the Camera's position from the player's position
		defaultOffset = transform.position - player.transform.position;
		adjustableOffset = defaultOffset;
	}

	// After the standard 'Update()' loop runs, and just before each frame is rendered..
	void LateUpdate ()
	{
		
		if (wallDetector.detectWall() == 1 && wallDetector.isWallCollision && stickyManager.isSticky)
		{
			if (!hasAdjustedOffset) 
			{
				resetOffset();
				adjustLeft();
			}
			Vector3 targetPosition = player.transform.position + adjustableOffset;
			Quaternion targetRotation = Quaternion.Euler(20.0f, -55.0f, 0.0f);
			
			moveCamera(targetPosition, targetRotation);
		}
		if (wallDetector.detectWall() == 2 && wallDetector.isWallCollision && stickyManager.isSticky)
		{
			if (!hasAdjustedOffset) 
			{
				resetOffset();
				adjustRight();
			}
			Vector3 targetPosition = player.transform.position + adjustableOffset;
			Quaternion targetRotation = Quaternion.Euler(20.0f, 55.0f, 0.0f);
			
			moveCamera(targetPosition, targetRotation);
		}
		if (wallDetector.detectWall() == 4 && wallDetector.isWallCollision && stickyManager.isSticky)
		{
			if (!hasAdjustedOffset) 
			{
				resetOffset();
				adjustBack();
			}
			Vector3 targetPosition = player.transform.position + adjustableOffset;
			Quaternion targetRotation = Quaternion.Euler(45.0f, 180.0f, 0.0f);
			
			moveCamera(targetPosition, targetRotation);
		}
		else
		{
			resetOffset();
			Vector3 targetPosition = player.transform.position + adjustableOffset;
			Quaternion targetRotation = Quaternion.Euler(45.0f, 0f, 0.0f);
			moveCamera(targetPosition, targetRotation);
			
			hasAdjustedOffset = false;
		}
		
	}
    
	public void resetCamera()
	{
		transform.position = player.transform.position + adjustableOffset;
	}
	
	private void adjustLeft()
	{
		float xOffset = 4.5f;
		float yOffset = -3.7f;
		float zOffset = 0.0f;
		adjustableOffset += new Vector3(xOffset, yOffset, zOffset);
		hasAdjustedOffset = true;
	}
	private void adjustRight()
	{
		float xOffset = -4.5f;
		float yOffset = -3.7f;
		float zOffset = 0.0f;
		adjustableOffset += new Vector3(xOffset, yOffset, zOffset);
		hasAdjustedOffset = true;
	}
	private void adjustBack()
	{
		float xOffset = 0f;
		float yOffset = 0f;
		float zOffset = 15.0f;
		adjustableOffset += new Vector3(xOffset, yOffset, zOffset);
		hasAdjustedOffset = true;
	}

	private void moveCamera(Vector3 targetPosition, Quaternion targetRotation)
	{
		Transform mainCameraTransform = Camera.main.transform;
		mainCameraTransform.position = Vector3.Lerp(mainCameraTransform.position, targetPosition, cameraLerpSpeed * Time.deltaTime);
		mainCameraTransform.rotation = Quaternion.Lerp(mainCameraTransform.rotation, targetRotation, cameraLerpSpeed * Time.deltaTime);
	}

	private void resetOffset()
	{
		adjustableOffset = defaultOffset;
	}
}