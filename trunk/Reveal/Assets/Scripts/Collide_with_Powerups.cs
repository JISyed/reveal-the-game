using UnityEngine;
using System.Collections;

public class Collide_with_Powerups : MonoBehaviour {
	
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	// Collision (powerup is a trigger)
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Powerup")
		{
			// Handle collisions with powerups  <--
			Destroy(other.gameObject);
		}
		
	}
	
}
