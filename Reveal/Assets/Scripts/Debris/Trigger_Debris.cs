using UnityEngine;
using System.Collections;

// Assumes ground is at y=0!

public class Trigger_Debris : MonoBehaviour {
	
	public GameObject debrisClump;
	public GameObject debrisShadow;
	
	private Vector3 spawnPosClump;
	private Vector3 spawnPosShadow;
	
	// Use this for initialization
	void Start () {
		spawnPosClump.Set(transform.position.x, 300.0f, transform.position.z);
		spawnPosShadow.Set(transform.position.x, 0.1f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Player_Prism")
		{
			Instantiate(debrisClump, spawnPosClump, transform.rotation);
			Instantiate(debrisShadow, spawnPosShadow, transform.rotation);
			Destroy(gameObject);
		}
	}
}
