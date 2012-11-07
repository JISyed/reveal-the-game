using UnityEngine;
using System.Collections;

public class Apply_Checkpoint : MonoBehaviour {
	
	public GameObject cpBulb;
	public Material matBulbOn;
	
	private bool checkpointAlreadyReached = false;
	private GameObject cpBulbRef;
	
	// Use this for initialization
	void Start () 
	{
		cpBulbRef = Instantiate(cpBulb, 
								new Vector3(transform.position.x, 0f, transform.position.z), 
								transform.rotation) as GameObject;
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
			cpBulbRef.renderer.material = matBulbOn;
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
