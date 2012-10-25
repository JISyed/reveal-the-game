using UnityEngine;
using System.Collections;

public class Radiate_Bullet_with_Light : MonoBehaviour {
	
	public GameObject newBullet;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "LightBeam(Clone)")
		{
			Instantiate(newBullet, transform.position, transform.rotation);
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
	}
	
}
