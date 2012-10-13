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
		startPos = gameObject.transform.position;
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
}
