using UnityEngine;
using System.Collections;

public class Fade_Muzzle_Flash : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.light.color -= Color.white * 2.5f * Time.deltaTime;
		
		if(gameObject.light.color.r < 0.1f)
		{
			Destroy(gameObject);
		}
	}
}
