using UnityEngine;
using System.Collections;

// This code should only be applied on for Prism-to-Wall collisions.
// This is because it reduces the number of lives.

public class Destroy_Collide_Wall : MonoBehaviour {
	
	public GameObject player;
	public GameObject deathParticles;
	public GameObject soundPlayer;
	// public string levelName;
	
	void Start() {}
	
	void Update() {}
	
	void OnCollisionEnter(Collision other)
	{
		//Application.LoadLevel (levelName);
		if(other.gameObject.tag == "Player")
		{
			Move_360.thrustSpeed = 700f;
			Player_Boost.onThrust = false;
		}
		
		// Play death sound
		Instantiate(soundPlayer, 
			        other.gameObject.transform.position, 
			        other.gameObject.transform.rotation);
		
		
		// Reduce the number of lives
		Manage_Game.numOfLives -= 1;
		
		Instantiate(deathParticles, 
			        other.gameObject.transform.position, 
			        other.gameObject.transform.rotation);
		
		Destroy(other.gameObject);
		
		Invoke("RevivePrism", Manage_Game.respawnTime);
	}
	
	void RevivePrism()
	{
		// Bad coding practice!!!
		// Needs to be more dynamic on a level-to-level basis.
		if(Manage_Game.numOfLives > 0)
		{
			Vector3 prismPos = Manage_Game.startPos;
			Instantiate(player, prismPos, player.transform.rotation);
		}
	}
}
