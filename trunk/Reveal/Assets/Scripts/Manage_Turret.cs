using UnityEngine;
using System.Collections;

public class Manage_Turret : MonoBehaviour {
	
	private Transform playerTransform;
	private float distanceToPlayer;
	private GameObject bulletReference;
	private bool alreadyFired = false;
	private float angleOfFire; 				// Between 0 and 180 degrees in respect to y-axis
	
	public float turretRange = 30.0f;
	public GameObject turretBullet;
	public float shotTimeInterval = 1.0f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Make sure there is a Player_Prism
		GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
		if(playerObj)
		{
			playerTransform = playerObj.transform;
		}
		
		// Assumes player exists
		if(playerTransform)
		{
			// Check if the player is in range
			distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
			if(distanceToPlayer < turretRange)
			{
				// Check to see if player is in angled range (don't shoot from behind)
				Vector3 playerVec = playerTransform.position - transform.position;
				playerVec.y = 0;
				playerVec.Normalize();
				angleOfFire = Vector3.Angle(Vector3.forward, playerVec);
				
				if(angleOfFire < 90f)
				{
					// Shoot bullet
					if(alreadyFired == false)
					{
						alreadyFired = true;
						bulletReference = Instantiate(turretBullet, transform.position, transform.rotation) as GameObject;
						bulletReference.transform.LookAt(playerTransform);
						Invoke("ResumeFiring", shotTimeInterval);
					}
				}
			}
		}
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, turretRange);
		Vector3 leftEnd = new Vector3(transform.position.x - turretRange, transform.position.y, transform.position.z);
		Vector3 rightEnd = new Vector3(transform.position.x + turretRange, transform.position.y, transform.position.z);
		Vector3 frontEnd = new Vector3(transform.position.x, transform.position.y, transform.position.z + turretRange);
		Gizmos.DrawLine(transform.position, leftEnd);
		Gizmos.DrawLine(transform.position, rightEnd);
		Gizmos.DrawLine(transform.position, frontEnd);
	}
	
	void ResumeFiring()
	{
		alreadyFired = false;
	}
}