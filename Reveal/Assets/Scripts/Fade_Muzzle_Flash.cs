using UnityEngine;
using System.Collections;

public class Fade_Muzzle_Flash : MonoBehaviour {

	public float fadeSpeed = 2.5f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.light.color -= Color.white * fadeSpeed * Time.deltaTime;
		
		if(gameObject.light.color.r < 0.05f)
		{
			Destroy(gameObject);
		}
	}
}
