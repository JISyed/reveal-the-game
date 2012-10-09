using UnityEngine;
using System.Collections;

public class Move_Lightwave : MonoBehaviour {
	
	public float speed = 50.0f;
	public GameObject player;
	
	// Use this for initialization
	void Start () 
	{
		audio.Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPosition = transform.position;
		newPosition.x += Time.deltaTime * speed * transform.forward.x;
		newPosition.z += Time.deltaTime * speed * transform.forward.z;
		transform.position = newPosition;
	}
}
