using UnityEngine;
using System.Collections;

public class Move_Lightwave : MonoBehaviour {
	
	public float speed = 50.0f;
	
	public static int currentColor;
	
	// Use this for initialization
	void Start () 
	{
		audio.Play ();
		
		// Change color depending on color state
		if(Manage_Game.colorState == (int) Manage_Game.Colors.red)
		{
			// Change light color
			gameObject.light.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			
			// Change material color
			Renderer jointRender = gameObject.GetComponentInChildren<Renderer>();
			jointRender.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
			
			// Change color state
			currentColor = (int) Manage_Game.Colors.red;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 newPosition = transform.position;
		newPosition.x += Time.deltaTime * speed * transform.forward.x;
		newPosition.z += Time.deltaTime * speed * transform.forward.z;
		transform.position = newPosition;
	}
}
