using UnityEngine;
using System.Collections;

public class Collide_Prism_to_Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision other)
	{
		Destroy(other.gameObject);
		Manage_Game.winLevel = true;
		Destroy(gameObject);
	}
}
