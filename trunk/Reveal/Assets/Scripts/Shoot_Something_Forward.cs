using UnityEngine;
using System.Collections;

public class Shoot_Something_Forward : MonoBehaviour {
	
	// This can be lightwaves or bullets
	public GameObject firedShot;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// Credit to CookingWithUnity
		if(Input.GetKeyDown(KeyCode.Space))
		{
			//Instantiate(firedShot ,transform.position, transform.rotation);
			GameObject projectile = Instantiate(firedShot ,transform.position, transform.rotation) as GameObject;
			
			
			
		}
	}
}
