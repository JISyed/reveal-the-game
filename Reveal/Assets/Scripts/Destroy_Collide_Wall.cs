using UnityEngine;
using System.Collections;

public class Destroy_Collide_Wall : MonoBehaviour {
	
	public string levelName;
	// Use this for initialization
	
	void OnCollisionEnter(Collision other)
	{
		//Application.LoadLevel (levelName);
		Destroy (other.gameObject);
	}
}
