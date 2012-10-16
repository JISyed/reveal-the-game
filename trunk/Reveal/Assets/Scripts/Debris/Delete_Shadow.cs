using UnityEngine;
using System.Collections;

// NOT WORKING
// I don't know why.

public class Delete_Shadow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter()
	{
		Destroy(gameObject);
	}
}
