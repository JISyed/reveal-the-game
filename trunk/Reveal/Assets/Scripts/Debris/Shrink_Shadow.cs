using UnityEngine;
using System.Collections;

public class Shrink_Shadow : MonoBehaviour {
	
	private float originalScale;
	private float sizeMultiplier = 0.3f;
	private float growSpeed = 0.15f;
	
	// Use this for initialization
	void Start () 
	{
		originalScale = transform.localScale.x;
		transform.localScale = changeShadowScale(originalScale * sizeMultiplier);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Grow shadow as long as it's under the original scale
		if(transform.localScale.x < originalScale)
		{
			sizeMultiplier += growSpeed * Time.deltaTime;
			transform.localScale = changeShadowScale(originalScale * sizeMultiplier);
		}
	}
	
	// Changes the scale of a square-plain the way you expect
	Vector3 changeShadowScale(float scaleValue)
	{
		Vector3 newScale = new Vector3(scaleValue, 1f, scaleValue);
		return newScale;
	}
}
