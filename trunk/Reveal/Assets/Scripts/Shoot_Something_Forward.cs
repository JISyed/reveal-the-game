using UnityEngine;
using System.Collections;

// This was suppose to be general.
// But now this is only reserved for shooting lightbeams.

public class Shoot_Something_Forward : MonoBehaviour {
	
	public GameObject firedShot;
	public float shootingOffset = 2.5f;
	
	// Use this for initialization
	void Start() {}
	
	// Update is called once per frame
	void Update () {
		
		// Credit to CookingWithUnity
		if(Input.GetButtonDown("Fire1") && Manage_Game.canMove) // Fire1 is defined in Input settings
		{
			if(Manage_Game.lightCount >= Manage_Game.helixCost)
			{
				// Decrease light energy
				Manage_Game.lightCount -= Manage_Game.helixCost;
				
				// Adjust the position of the lightbeam forawrd from the prism
				Vector3 forwardOffset = transform.position + (transform.forward * shootingOffset);
				
				// Create lightbeam
				Instantiate(firedShot, forwardOffset, transform.rotation);
			}				
		}
	}
}
