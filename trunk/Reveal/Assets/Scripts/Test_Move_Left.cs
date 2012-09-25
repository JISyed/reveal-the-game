using UnityEngine;
using System.Collections;

public class Test_Move_Left : MonoBehaviour {

	public float speed = 10;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.x += Time.deltaTime * speed * (-1); // -1 to move left
		transform.position = newPosition;;
	}
}
