using UnityEngine;
using System.Collections;

// This code should only be applied on for Prism-to-Wall collisions.
// This is because it reduces the number of lives.
public class Destroy_Collide_Wall : MonoBehaviour {
	
	public GameObject player;
	// public string levelName;
	// Use this for initialization
	
	void OnCollisionEnter(Collision other)
	{
		//Application.LoadLevel (levelName);
		Destroy (other.gameObject);
		
		// Reduce the number of lives
		//if(other.gameObject == player) /// This if statement does not work!
		//{
			Manage_Game.numOfLives -= 1;
		//}
	}
}
