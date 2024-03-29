using UnityEngine;
using System.Collections;

public class Apply_Checkpoint : MonoBehaviour {
	
	public GameObject cpBulb;
	public GameObject cpParticles;
	public Material matBulbOn;
	
	private bool checkpointAlreadyReached = false;
	private GameObject cpBulbRef;
	private GameObject cpParticlesReference;
	GameObject thePlayer;
	
	public static Texture2D checkpoint;
	public static float checkpointYIncrementer = 0;
	public static bool doCheckpointAnimation = false;
	// Use this for initialization
	void Start () 
	{
		cpBulbRef = Instantiate(cpBulb, 
								new Vector3(transform.position.x, 0f, transform.position.z), 
								transform.rotation) as GameObject;
		doCheckpointAnimation = false;
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
			audio.Play();
			cpParticlesReference = Instantiate(cpParticles,
								   new Vector3(transform.position.x, 0.1f, transform.position.z),
								   transform.rotation) as GameObject;
			cpParticlesReference.transform.RotateAround(cpParticlesReference.transform.position, 
													    Vector3.forward, 
														90.0f);
			// No need to check collisions again
			gameObject.collider.enabled = false;
			
			//SJH Added 11/12/2012
			if(!doCheckpointAnimation)
			{
				doCheckpointAnimation = true;
				checkpointYIncrementer = 0;
				Invoke ("StopFloating", 1.5f);
			}
			
		}
	}
	
	void Update()
	{
		if(doCheckpointAnimation)
			checkpointYIncrementer += (12.0f * Time.deltaTime);
	}
	void StopFloating()
	{
		doCheckpointAnimation = false;	
		checkpointYIncrementer = 0;
		
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
