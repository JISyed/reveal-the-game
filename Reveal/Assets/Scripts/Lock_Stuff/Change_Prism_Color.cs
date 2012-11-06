using UnityEngine;
using System.Collections;

public class Change_Prism_Color : MonoBehaviour {
	
	private const float LIGHT_RANGE_VALUE = 35f;
	private const float LIGHT_INTENSITY_VALUE = 0.65f;
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
			light.range = LIGHT_RANGE_VALUE;
			light.intensity = LIGHT_INTENSITY_VALUE + 0.01f;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.red)
		{
			renderer.material.color = Manage_Game.col_red;
			light.color = Manage_Game.col_red;
			light.range = LIGHT_RANGE_VALUE + 6f;
			light.intensity = LIGHT_INTENSITY_VALUE + 0.04f;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.green)
		{
			renderer.material.color = Manage_Game.col_green;
			light.color = Manage_Game.col_green;
			light.range = LIGHT_RANGE_VALUE + 4f;
			light.intensity = LIGHT_INTENSITY_VALUE + 0.02f;
		}
		
		if(Manage_Game.colorState == (int) Manage_Game.Colors.blue)
		{
			renderer.material.color = Manage_Game.col_blue;
			light.color = Manage_Game.col_blue;
			light.range = LIGHT_RANGE_VALUE + 9f;
			light.intensity = LIGHT_INTENSITY_VALUE + 0.07f;
		}
	}
}
