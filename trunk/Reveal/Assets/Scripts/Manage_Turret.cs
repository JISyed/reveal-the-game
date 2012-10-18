using UnityEngine;
using System.Collections;

public class Manage_Turret : MonoBehaviour {
	
	private Transform playerTransform;
	private float distanceToPlayer;
	private GameObject bulletReference;
	private GameObject barrelReference;
	private bool alreadyFired = false;
	private float angleOfFire; 				// Between 0 and 180 degrees in respect to y-axis
	
	public float turretRange = 30.0f;
	public GameObject turretBullet;
	public float shotTimeInterval = 1.0f;
	public GameObject barrelOfTheTurret;
	
	// Use this for initialization
	void Start () 
	{
		barrelReference = Instantiate(barrelOfTheTurret, transform.position, transform.rotation) as GameObject;
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
				angleOfFire = Vector3.Angle(transform.forward, playerVec);
				
				if(angleOfFire < 90f)
				{
					// Aim barrel
					barrelReference.transform.LookAt(playerTransform);
					
					// Shoot bullet
					if(alreadyFired == false)
					{
						alreadyFired = true;
						bulletReference = Instantiate(turretBullet, transform.position + barrelReference.transform.forward * 8f, transform.rotation) as GameObject;
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
		Gizmos.DrawLine(transform.position, transform.position + (transform.right * turretRange));
		Gizmos.DrawLine(transform.position, transform.position + (transform.right * turretRange * -1));
		Gizmos.DrawLine(transform.position, transform.position + (transform.forward * turretRange));
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + (transform.forward * (turretRange/2)));
	}
	
	void ResumeFiring()
	{
		alreadyFired = false;
	}
}
