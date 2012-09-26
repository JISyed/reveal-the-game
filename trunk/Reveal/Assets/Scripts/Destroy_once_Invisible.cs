using UnityEngine;
using System.Collections;

public class Destroy_once_Invisible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	// Credit to CookingWithUnity Tutorials
	void OnBecameInvisible() {
		Destroy(gameObject);
	}
}
