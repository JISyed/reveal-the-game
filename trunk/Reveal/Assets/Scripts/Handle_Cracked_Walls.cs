using UnityEngine;
using System.Collections;

public class Handle_Cracked_Walls : MonoBehaviour {
	
	public GameObject wallPrefab;
	public GameObject breakingSoundSource;
	public GameObject flashPrefab;
	public GameObject wallPrefab2;
	public GameObject wallPrefab3;
	public GameObject ptfxCracking;
	public GameObject ptfxDust;
	
	private GameObject wallReference;
	private GameObject flashReference;
	private GameObject ptfxCrackingRef;
	private GameObject ptfxDustReference;
	private GameObject ptfxDustReference2;
	private int health = 3;
	
	// Use this for initialization
	void Start () 
	{
		// Disable renderer
		renderer.enabled = false;
		
		// Make a wall at it's position
		wallReference = Instantiate(wallPrefab, transform.position, transform.rotation) as GameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health < 1)
		{
			// Play a wall breaking sound here.
			Instantiate(breakingSoundSource, transform.position, transform.rotation);
			ptfxDustReference =  Instantiate(ptfxDust, wallReference.transform.position, wallReference.transform.rotation) as GameObject;
			ptfxDustReference.transform.Translate(Vector3.up * -12f);
			ptfxDustReference.transform.Translate(transform.right * -10f);
			ptfxDustReference2 =  Instantiate(ptfxDust, wallReference.transform.position, wallReference.transform.rotation) as GameObject;
			ptfxDustReference2.transform.Translate(Vector3.up * -12f);
			ptfxDustReference2.transform.Translate(transform.right * 10f);
			Destroy(wallReference);
			Destroy(gameObject);
		}
	}
	
	// Collision with lightbeams or turret bullets (because of physics settings)
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name == "Turret_Bullet_Charged(Clone)")
		{
			Destroy(other.gameObject);
			audio.Play();
			health--;
			flashReference = Instantiate(flashPrefab, 
										 transform.position + (transform.forward * 9f), 
										 transform.rotation) as GameObject;
			flashReference.transform.Translate(Vector3.up * 1.5f);
			ptfxCrackingRef = Instantiate(ptfxCracking,
										  transform.position + (transform.forward * 7f),
										  transform.rotation) as GameObject;
			ptfxCrackingRef.transform.Translate(Vector3.up * -2.0f);
			if(health == 2)
			{
				Destroy(wallReference);
				wallReference = Instantiate(wallPrefab2, transform.position, transform.rotation) as GameObject;
			}
			if(health == 1)
			{
				Destroy(wallReference);
				wallReference = Instantiate(wallPrefab3, transform.position, transform.rotation) as GameObject;
			}
		}
		if(other.gameObject.name == "Turret_Bullet(Clone)")
		{
			Destroy(other.gameObject);
		}
	}
}
