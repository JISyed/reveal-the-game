using UnityEngine;
using System.Collections;

public class Move_with_WSAD : MonoBehaviour {
	
	// Modifyable value in Unity Editor (default to 5)
	public float speed = 15.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		newPosition.z += Input.GetAxis("Vertical")   * Time.deltaTime * speed;
		transform.position = newPosition;
	}
}
