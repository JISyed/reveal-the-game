using UnityEngine;
using System.Collections;

public class Apply_Checkpoint : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	// Collision
	void OnTriggerEnter(Collider other)
	{
		
	}
	
	// Gizmos
	void OnDrawGizmos()
	{
		Gizmos.color = new Color(0.6f, 0.0f, 0.9f);
		Gizmos.DrawCube(transform.position, new Vector3(1f,1f,1f));
		Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, 
														    transform.localScale.y, 
														    transform.localScale.z)  );
	}
	
	
}
