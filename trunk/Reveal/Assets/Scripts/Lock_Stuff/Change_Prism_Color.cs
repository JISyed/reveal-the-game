using UnityEngine;
using System.Collections;

public class Change_Prism_Color : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Manage_Game.colorState == (int) Manage_Game.Colors.white)
		{
			renderer.material.color = new Color(1.0f, 1.0f, 1.0f);
			light.color = new Color(1.0f, 1.0f, 1.0f);
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.red)
		{
			renderer.material.color = new Color(1.0f, 0.0f, 0.0f);
			light.color = new Color(1.0f, 0.0f, 0.0f);
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.green)
		{
			renderer.material.color = new Color(0.0f, 1.0f, 0.0f);
			light.color = new Color(0.0f, 1.0f, 0.0f);
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.blue)
		{
			renderer.material.color = new Color(0.0f, 0.0f, 1.0f);
			light.color = new Color(0.0f, 0.0f, 1.0f);
		}
	}
}
