using UnityEngine;
using System.Collections;

public class Camera_Follow_Player : MonoBehaviour {
	
	private Vector3 deathPoint;
	private float startTime;
	private Vector3 cameraStartPos;
	private float relocationTime = 3.0f;
	
	GameObject thePlayer;
	public float cameraHeightOffset = 50f;
	
	// Start
	void Start() {}
	
	// Update
	void Update () 
	{
		Vector3 newPosition = transform.position;	
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		
		if (thePlayer)
		{
			newPosition = new Vector3(thePlayer.transform.position.x, 
									  thePlayer.transform.position.y + cameraHeightOffset, 
									  thePlayer.transform.position.z);
			// Update the deathpoint
			deathPoint = newPosition;
			startTime = Time.time;
			cameraStartPos = new Vector3(Manage_Game.startPos.x, 
									     Manage_Game.startPos.y + cameraHeightOffset, 
									     Manage_Game.startPos.z);
		}
		else
		{
			// Credit to Jaap Kreijkamp 
			// http://answers.unity3d.com/questions/8291/how-to-move-a-gameobject-from-his-position-to-a-xy.html
			newPosition = Vector3.Lerp(deathPoint, 
									   cameraStartPos, 
									   (Time.time - startTime) / relocationTime );
		}
		
		//GameObject.FindGameObjectWithTag("player");
		transform.position = newPosition;
	}
}
