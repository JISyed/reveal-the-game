using UnityEngine;
using System.Collections;

// Assumes movement in local Z axis only!

public class Move_Back_and_Forth_Z : MonoBehaviour {

	public float maxMovingDistance = 12.0f;
	public float movingSpeed = 4.0f;
	
	private Vector3 startPos;
	private int moveDirection = 1;
	
	// Use this for initialization
	void Start () 
	{
		startPos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Credit to cooking with Unity Tutorials
		Vector3 newPosition = transform.position;
		newPosition.z += moveDirection * Time.deltaTime * movingSpeed;
		transform.position = newPosition;
		
		if(transform.position.z > (startPos.z + maxMovingDistance) && moveDirection > 0)
		{
			moveDirection = -1;
		}
		
		if(transform.position.z < (startPos.z - maxMovingDistance) && moveDirection < 0)
		{
			moveDirection = 1;
		}
	}
}
