using UnityEngine;
using System.Collections;

public class Move_Clump : MonoBehaviour {
	
	public float fallSpeed = 65.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Credit to cooking with Unity Tutorials
		if(transform.position.y > 0) // This assumes the floor is at y=0!
		{
			Vector3 newPosition = transform.position;
			newPosition.y -= Time.deltaTime * fallSpeed;
			transform.position = newPosition;
		}
	}
}
