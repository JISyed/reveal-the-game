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
		
		if (thePlayer)
		{
			
			newPosition = thePlayer.transform.position;
			newPosition.y = thePlayer.transform.position.y + 50;
		}
		
		//GameObject.FindGameObjectWithTag("player");
		transform.position = newPosition;
	}
}
