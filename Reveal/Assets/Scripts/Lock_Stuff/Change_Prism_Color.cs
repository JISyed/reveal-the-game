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
			light.range = 25f;
			light.intensity = 0.56f;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.red)
		{
			renderer.material.color = Manage_Game.col_red;
			light.color = Manage_Game.col_red;
			light.range = 31f;
			light.intensity = 0.59f;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.green)
		{
			renderer.material.color = Manage_Game.col_green;
			light.color = Manage_Game.col_green;
			light.range = 29f;
			light.intensity = 0.57f;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.blue)
		{
			renderer.material.color = Manage_Game.col_blue;
			light.color = Manage_Game.col_blue;
			light.range = 34f;
			light.intensity = 0.62f;
		}
	}
}
