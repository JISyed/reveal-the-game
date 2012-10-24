using UnityEngine;
using System.Collections;

public class Set_Color_State : MonoBehaviour {

	public string colorToChangeInto;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	// When player hits gem
	void OnTriggerEnter(Collider other)
	{
		if(colorToChangeInto == "Red" || colorToChangeInto == "red")
		{
			Manage_Game.colorState = (int) Manage_Game.Colors.red;
		}
		else if(colorToChangeInto == "Green" || colorToChangeInto == "green")
		{
			Manage_Game.colorState = (int) Manage_Game.Colors.green;
		}
		else if(colorToChangeInto == "Blue" || colorToChangeInto == "blue")
		{
			Manage_Game.colorState = (int) Manage_Game.Colors.blue;
		}
		else
		{
			Debug.Log("Invalid string for \"Set_Color_State.colorToChangeInto\"");
		}
	}
}
