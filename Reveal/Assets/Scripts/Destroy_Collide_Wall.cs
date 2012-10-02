using UnityEngine;
using System.Collections;

// This code should only be applied on for Prism-to-Wall collisions.
// This is because it reduces the number of lives.
public class Destroy_Collide_Wall : MonoBehaviour {
	
	public GameObject player;
	// public string levelName;
	
	void Start()
	{
	}
	
	void Update()
	{
	}
	
	void OnCollisionEnter(Collision other)
	{
		//Application.LoadLevel (levelName);
		Destroy (other.gameObject);
		
		// Reduce the number of lives
		//if(other.gameObject == player) /// This if statement does not work!
		//{
			Manage_Game.numOfLives -= 1;
			if(Manage_Game.numOfLives > 0)
			{
				Invoke("RevivePrism", 3);
			}
		//}
	}
	
	void RevivePrism()
	{
		// Bad coding practice!!!
		// Needs to be more dynamic on a level-to-level basis.
		Vector3 prismPos = new Vector3(-87.0f, 7.36f, 36.0f);
		Instantiate(player, prismPos, player.transform.rotation);
	}
}
