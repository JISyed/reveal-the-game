using UnityEngine;
using System.Collections;

public class Apply_Checkpoint : MonoBehaviour {
	
	private bool checkpointAlreadyReached = false;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	// Collision
	void OnTriggerEnter(Collider other)
	{
		// Set new checkpoint
		if(checkpointAlreadyReached == false)
		{
			checkpointAlreadyReached = true;
			Manage_Game.startPos = transform.position;
			// No need to check collisions again
			gameObject.collider.enabled = false;
		}
	}
	
	// Gizmos
	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0.6f, 0.0f, 0.9f); // Purple
		Gizmos.DrawCube(transform.position, new Vector3(1f,1f,1f));
		Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, 
														    transform.localScale.y, 
														    transform.localScale.z)  );
	}
	
	
}
