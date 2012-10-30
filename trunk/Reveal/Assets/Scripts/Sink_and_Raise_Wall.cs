using UnityEngine;
using System.Collections;

// Assumes the standard height is at y = 12;

public class Sink_and_Raise_Wall : MonoBehaviour {
	
	public float timeRaised = 5.0f;				// Time wall stays raised
	public float timeSunk = 8.0f;				// Time wall stays sunk
	public float timeRaisingStalled = 3.0f;		// Time when raising of wall is temporarly stalled
	
	public float movingSpeed = 4.0f;
	private int movingDirection = -1;	// -1 = sinking; 1 = raising
	
	private bool shouldMove = true;
	private bool wasStalled = false;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Credit to cooking with Unity Tutorials
		if(shouldMove)
		{
			Vector3 newPosition = transform.position;
			newPosition.y += movingDirection * Time.deltaTime * movingSpeed;
			transform.position = newPosition;
		}
			
		// Change directions and temporarly stop wall moving
		if(transform.position.y < -13.0f && movingDirection < 0)
		{
			movingDirection = 1; // raise if sunk too far
			shouldMove = false;
			Invoke("MakeMoveAgain", timeSunk);
		}
		if(transform.position.y > 11.9f && movingDirection > 0)
		{
			movingDirection = -1; // sink if raised too far
			shouldMove = false;
			wasStalled = false; // Reset stalling state
			Invoke("MakeMoveAgain", timeRaised);
		}
		
		// Stall the raising of the wall as a cue of warning
		if(transform.position.y > -11.0f && movingDirection > 0 && wasStalled == false)
		{
			wasStalled = true;
			shouldMove = false;
			Invoke("MakeMoveAgain", timeRaisingStalled);
		}
	}
	
	// To distinguish sinking walls from other walls
	void OnDrawGizmos () 
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position + (Vector3.up * 14), 2);
	}
	
	void MakeMoveAgain()
	{
		shouldMove = true;
	}
}
