using UnityEngine;
using System.Collections;

public class Move_360 : MonoBehaviour {
	
	public float rotateSpeed = 180.0f;
	public float thrustSpeed = 700.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime) );
		//if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		//{
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