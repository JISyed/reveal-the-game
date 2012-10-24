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
			renderer.material.color = Manage_Game.col_white;
			light.color = Manage_Game.col_white;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.red)
		{
			renderer.material.color = Manage_Game.col_red;
			light.color = Manage_Game.col_red;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.green)
		{
			renderer.material.color = Manage_Game.col_green;
			light.color = Manage_Game.col_green;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.blue)
		{
			renderer.material.color = Manage_Game.col_blue;
			light.color = Manage_Game.col_blue;
		}
	}
}
