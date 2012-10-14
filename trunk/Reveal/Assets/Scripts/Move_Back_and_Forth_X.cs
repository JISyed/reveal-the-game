using UnityEngine;
using System.Collections;

// Assumes movement in local X axis only!

public class Move_Back_and_Forth_X : MonoBehaviour {
	
	public float maxMovingDistance = 12.0f;
	public float movingSpeed = 4.0f;
	
	private Vector3 startPos;
	private int moveDirection = 1;
	
	// Use this for initialization
	void Start () 
	{
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Credit to cooking with Unity Tutorials
		Vector3 newPosition = transform.position;
		newPosition.x += moveDirection * Time.deltaTime * movingSpeed;
		transform.position = newPosition;
		
		if(transform.position.x > (startPos.x + maxMovingDistance) && moveDirection > 0)
		{
			moveDirection = -1;
		}
		
		if(transform.position.x < (startPos.x - maxMovingDistance) && moveDirection < 0)
		{
			moveDirection = 1;
		}
	}
	
	// Visualize the move path
	void OnDrawGizmos()
	{
		// Credit to Cooking with Unity Tutorials
		Vector3 gizPoint = transform.position;
		Vector3 leftEnd = new Vector3(gizPoint.x - maxMovingDistance, gizPoint.y, gizPoint.z);
		Vector3 rightEnd = new Vector3(gizPoint.x + maxMovingDistance, gizPoint.y, gizPoint.z);
		Gizmos.DrawLine(gizPoint, leftEnd);
		Gizmos.DrawLine(gizPoint, rightEnd);
		Gizmos.DrawWireSphere(leftEnd, 1.0f);
		Gizmos.DrawWireSphere(rightEnd, 1.0f);
		Gizmos.DrawWireSphere(gizPoint, 1.0f);
	}
}
