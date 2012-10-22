using UnityEngine;
using System.Collections;

public class Move_360 : MonoBehaviour {
	
	public float rotateSpeed = 155.0f;
	public static float thrustSpeed = 700.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if((Input.GetKey("left")) || (Input.GetKey ("right")))
		{
			switch(Manage_Game.difficulty)
			{
			case 1:
				Manage_Game.lightRegen = 0.7f;
				break;
			case 2:
				Manage_Game.lightRegen = 0.4f;
				break;
			case 3:
				Manage_Game.lightRegen = 0.0f;
				break;
			default:
				Manage_Game.lightRegen = 0.7f;
				break;
			}
		}
		else
		{
			switch(Manage_Game.difficulty)
			{
			case 1:
				Manage_Game.lightRegen = 7.0f;
				break;
			case 2:
				Manage_Game.lightRegen = 4.0f;
				break;
			case 3:
				Manage_Game.lightRegen = 0.0f;
				break;
			default:
				Manage_Game.lightRegen = 7.0f;
				break;
			}
		}
		
		//Debug.Log (Manage_Game.lightRegen);
		transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime) );
		
		// Prevents sudden zipping at start of level
		//if(Pause_at_Start.gameStarted)
		//{
		if(Manage_Game.canMove)
			rigidbody.AddRelativeForce(Vector3.forward * thrustSpeed * Time.deltaTime);
		//}

	}
}

/* ORIGINAL JAVASCRIPT
 * by Eric5h5
 * http://answers.unity3d.com/questions/18846/how-would-i-do-asteroids-style-moving.html

var rotateSpeed = 360.0;
var thrustSpeed = 25.0;

function FixedUpdate() { 
   transform.Rotate (Vector3.up * (Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime) ); 

   if (Input.GetButton("Thrust") ) { 
      rigidbody.AddRelativeForce (Vector3.forward * thrustSpeed * Time.deltaTime); 
   }
}

*/