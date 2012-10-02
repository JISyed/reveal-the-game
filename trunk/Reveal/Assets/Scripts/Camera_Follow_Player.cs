using UnityEngine;
using System.Collections;

public class Camera_Follow_Player : MonoBehaviour {
	public GameObject player;
	
	void Start()
	{
	}
	
	void Update () 
	{
		Vector3 newPosition = transform.position;	
		
		if((!player) && (!Manage_Game.gameOver))
		{
			//newPosition.x = 0;
			//newPosition.z = 0;
			//newPosition.y = 150;
		}
		else if ((!player) && (Manage_Game.gameOver))
		{
			newPosition.x = 0;
			newPosition.z = 0;
			newPosition.y = 150;
		}
		else
		{
			newPosition = player.transform.position;
			newPosition.y = player.transform.position.y + 50;
		}
		
		transform.position = newPosition;
	}
}
