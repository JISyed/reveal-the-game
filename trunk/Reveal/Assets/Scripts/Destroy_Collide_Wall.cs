using UnityEngine;
using System.Collections;

// This code should only be applied on for Prism-to-Wall collisions.
// This is because it reduces the number of lives.

public class Destroy_Collide_Wall : MonoBehaviour {
	
	public GameObject player;
	public GameObject deathParticles;
	public GameObject soundPlayer;
	
	void Start() {}
	
	void Update() {}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			Move_360.thrustSpeed = 700f;
			Player_Boost.onThrust = false;
		
		
			// Play death sound
			Instantiate(soundPlayer, 
				        other.gameObject.transform.position, 
			    	    other.gameObject.transform.rotation);
		
		
			// Reduce the number of lives
		
			if(Manage_Game.infiniteLives == false)
			{
				Manage_Game.numOfLives -= 1;
			}
		
			Instantiate(deathParticles, 
			        	other.gameObject.transform.position, 
			        	other.gameObject.transform.rotation);
		
			Destroy(other.gameObject);
			
			Manage_Game.colorState = (int) Manage_Game.Colors.white;
		
			Invoke("RevivePrism", Manage_Game.respawnTime);
		}
		
		if(gameObject.name == "Turret_Bullet(Clone)" && 
			(other.gameObject.name == "Player_Prism" || other.gameObject.name == "Player_Prism(Clone)"))
		{
			renderer.enabled = false;
			collider.enabled = false;
		}
		
		if(gameObject.name == "Turret_Bullet_Charged(Clone)" &&
			(other.gameObject.name == "Player_Prism" || other.gameObject.name == "Player_Prism(Clone)"))
		{
			renderer.enabled = false;
			collider.enabled = false;
		}
		
		if(gameObject.tag == "Wall_Piece" &&
			(other.gameObject.name == "Turret_Bullet(Clone)" || other.gameObject.name == "Turret_Bullet_Charged(Clone)") )
		{
			other.gameObject.collider.enabled = false;
			other.gameObject.renderer.enabled = false;
		}
	}
	
	void RevivePrism()
	{
		if(Manage_Game.numOfLives > 0)
		{
			Manage_Game.lightCount = 100f;
			Vector3 prismPos = Manage_Game.startPos;
			Instantiate(player, prismPos, player.transform.rotation);
		}
	}
}
