using UnityEngine;
using System.Collections;

public class Camera_Follow_Player : MonoBehaviour {
	
	public float cameraHeight = 150.0f;
	
	GameObject thePlayer;
	
	void Start() {}
	
	void Update () 
	{
		Vector3 newPosition = transform.position;	
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		if((!thePlayer) && (!Manage_Game.gameOver))
		{
			//newPosition.x = 0;
			//newPosition.z = 0;
			//newPosition.y = 150;
		}
		else if ((!thePlayer) && (Manage_Game.gameOver))
		{
			newPosition.x = 0;
			newPosition.z = 0;
			newPosition.y = cameraHeight;
		}
		else
		{
			
			newPosition = thePlayer.transform.position;
			newPosition.y = thePlayer.transform.position.y + 50;
		}
		
		//GameObject.FindGameObjectWithTag("player");
		transform.position = newPosition;
	}
}
