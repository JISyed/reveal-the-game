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
		if(Manage_Game.colorState == (int) Manage_Game.Colors.white)
		{
			// Change light color
			gameObject.light.color = Manage_Game.col_white;
			
			// Change material color
			Renderer jointRender = gameObject.GetComponentInChildren<Renderer>();
			jointRender.material.color = Manage_Game.col_white;
			
			// Change color state
			currentColor = (int) Manage_Game.Colors.white;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.red)
		{
			// Change light color
			gameObject.light.color = Manage_Game.col_red;
			
			// Change material color
			Renderer jointRender = gameObject.GetComponentInChildren<Renderer>();
			jointRender.material.color = Manage_Game.col_red;
			
			// Change color state
			currentColor = (int) Manage_Game.Colors.red;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.green)
		{
			// Change light color
			gameObject.light.color = Manage_Game.col_green;
			
			// Change material color
			Renderer jointRender = gameObject.GetComponentInChildren<Renderer>();
			jointRender.material.color = Manage_Game.col_green;
			
			// Change color state
			currentColor = (int) Manage_Game.Colors.green;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.blue)
		{
			// Change light color
			gameObject.light.color = Manage_Game.col_blue;
			
			// Change material color
			Renderer jointRender = gameObject.GetComponentInChildren<Renderer>();
			jointRender.material.color = Manage_Game.col_blue;
			
			// Change color state
			currentColor = (int) Manage_Game.Colors.blue;
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
