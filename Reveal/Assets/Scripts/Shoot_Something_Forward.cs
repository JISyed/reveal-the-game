using UnityEngine;
using System.Collections;

public class Shoot_Something_Forward : MonoBehaviour {
	
	// This can be lightwaves or bullets
	public GameObject firedShot;
	
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		
		// Credit to CookingWithUnity
		if(Input.GetButtonDown("Fire1")) // Fire1 is defined in Input settings
		{
			if(Manage_Game.lightCount >= Manage_Game.helixCost)
			{
				Manage_Game.lightCount -= Manage_Game.helixCost;
				Instantiate(firedShot, transform.position, transform.rotation);
				//firedShot.transform.RotateAround(Vector3.forward, -90.0f);
			}
			//GameObject projectile = Instantiate(firedShot ,transform.position, transform.rotation) as GameObject;
			
			
			
		}
	}
}
