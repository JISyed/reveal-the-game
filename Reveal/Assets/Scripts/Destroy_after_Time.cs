using UnityEngine;
using System.Collections;

public class Destroy_after_Time : MonoBehaviour {

	public float timeInSeconds = 10.0f;
	
	// Use this for initialization
	void Start () {
		Destroy(gameObject, timeInSeconds);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
