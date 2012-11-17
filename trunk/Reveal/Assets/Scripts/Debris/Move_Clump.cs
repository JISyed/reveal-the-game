using UnityEngine;
using System.Collections;

public class Move_Clump : MonoBehaviour {
	
	public GameObject ptfxDust;
	
	public float fallSpeed = 65.0f;
	
	private bool soundAlreadyPlayed = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Credit to cooking with Unity Tutorials
		if(transform.position.y > 0) // This assumes the floor is at y=0!
		{
			Vector3 newPosition = transform.position;
			newPosition.y -= Time.deltaTime * fallSpeed;
			transform.position = newPosition;
		}
		
		if(transform.position.y <= 0.1f)
		{
			if(soundAlreadyPlayed == false)
			{
				soundAlreadyPlayed = true;
				gameObject.audio.Play();
				Instantiate(ptfxDust, transform.position, transform.rotation);
			}
		}
	}
}
