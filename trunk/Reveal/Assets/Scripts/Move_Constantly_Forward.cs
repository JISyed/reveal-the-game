using UnityEngine;
using System.Collections;

public class Move_Constantly_Forward : MonoBehaviour {
	
	public float speed = 50.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.z += Time.deltaTime * speed;
		transform.position = newPosition;
	}
}
