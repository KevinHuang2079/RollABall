using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    private bool isLeft;
    private bool isForward;
    private bool isRight;
    private bool isBack;
    public bool isGround;
    public STICKY stickyManager;
    public bool isWallCollision;
    
    
    
    public int detectWall()
    {
        RaycastHit hit;
        int layerMask = 3 << LayerMask.NameToLayer("Wall");
        Vector3 worldLeft = Vector3.left;
        Vector3 worldRight = Vector3.right;
        Vector3 worldForward = Vector3.forward;
        Vector3 worldBack = Vector3.back;
        float rayDistance = 1.0f;
		
        if (Physics.Raycast(transform.position, worldLeft, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, worldLeft * hit.distance, Color.yellow);
            //print("leftRaycast");
            isGround = false;
            return 1;
        }
        if (Physics.Raycast(transform.position, worldRight, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, worldRight * hit.distance, Color.yellow);
            //print("rightRaycast");
            isGround = false;
            return 2;
        }
        if (Physics.Raycast(transform.position, worldForward, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, worldForward * hit.distance, Color.yellow);
            //print("forwardRaycast");
            isGround = false;
            return 3;
        }
        if (Physics.Raycast(transform.position, worldBack, out hit, rayDistance, layerMask))
        {
            Debug.DrawRay(transform.position, worldBack * hit.distance, Color.yellow);
            //print("backRaycast");
            isGround = false;
            return 4;
        }
        else 
        {
            Debug.DrawRay(transform.position, worldLeft * rayDistance, Color.white);
            Debug.DrawRay(transform.position, worldRight * rayDistance, Color.white);
            Debug.DrawRay(transform.position, worldForward * rayDistance, Color.white);
            Debug.DrawRay(transform.position, worldBack * rayDistance, Color.white);
           
        }

        isGround = true;
        return 0;
    }
    
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            isWallCollision  = true;
        }
        else
        {
            isWallCollision  = false;
        }
    }
    
}
