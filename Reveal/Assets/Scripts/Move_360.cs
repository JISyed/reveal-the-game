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
		
		
		//Debug.Log (Manage_Game.lightRegen);
		transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime) );
		
		// Prevents sudden zipping at start of level
		//if(Pause_at_Start.gameStarted)
		//{
		if(Manage_Game.canMove)
		{
			rigidbody.AddRelativeForce(Vector3.forward * thrustSpeed * Time.deltaTime);
		}
		

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