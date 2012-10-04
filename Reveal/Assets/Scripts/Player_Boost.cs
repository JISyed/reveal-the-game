using UnityEngine;
using System.Collections;

public class Player_Boost : MonoBehaviour {
	
	public static bool onThrust = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if((Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown (KeyCode.RightShift)))
		{
			if(onThrust)
			{
				Move_360.thrustSpeed = 700f;
				onThrust = false;
			}
			else
			{
				Move_360.thrustSpeed *= 2;
				onThrust = true;
			}
			
			if(Manage_Game.lightCount <= 0)
			{
				Move_360.thrustSpeed = 700f;
				onThrust = false;	
			}
				
		}
	}
}
