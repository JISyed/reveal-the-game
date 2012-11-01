using UnityEngine;
using System.Collections;

// Assumes ground is at y=0!

public class Trigger_Debris : MonoBehaviour {
	
	public GameObject debrisClump;
	public GameObject debrisShadow;
	public GameObject debrisSpotlight;
	
	private Vector3 spawnPosClump;
	private Vector3 spawnPosShadow;
	private Vector3 spawnPosSpotlight;
	
	// Use this for initialization
	void Start () {
		renderer.enabled = false;
		spawnPosClump.Set(transform.position.x, 300.0f, transform.position.z);
		spawnPosShadow.Set(transform.position.x, 0.1f, transform.position.z);
		spawnPosSpotlight.Set(transform.position.x, 190.0f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player_Prism" || other.gameObject.name == "Player_Prism(Clone)")
		{
			Instantiate(debrisClump, spawnPosClump, transform.rotation);
			Instantiate(debrisShadow, spawnPosShadow, transform.rotation);
			GameObject theSpotlight = Instantiate(debrisSpotlight, spawnPosSpotlight, Quaternion.identity) as GameObject;
			theSpotlight.transform.Rotate(Vector3.right, 90.0f);
			Destroy(gameObject);
		}
	}
}
