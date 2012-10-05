using UnityEngine;
using System.Collections;

public class Destroy_after_Time : MonoBehaviour {
	
	// Will not do anything if 0
	public float timeInSeconds = 10.0f;
	
	// Use this for initialization
	void Start () {
		if(timeInSeconds > 0)
		{
			Destroy(gameObject, timeInSeconds);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
