using UnityEngine;
using System.Collections;

public class Player_Boost : MonoBehaviour {
	
	public static bool onThrust = false;
	
	public float boostMultiplier = 2.5f;
	public float defaultSlowSpeed = 700.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if((Input.GetKeyDown(KeyCode.LeftShift)) || (Input.GetKeyDown(KeyCode.RightShift)))
		{
			if(onThrust)
			{
				Move_360.thrustSpeed = defaultSlowSpeed;
				onThrust = false;
			}
			else
			{
				Move_360.thrustSpeed *= boostMultiplier;
				onThrust = true;
			}
			
			if(Manage_Game.lightCount <= 0)
			{
				Move_360.thrustSpeed = defaultSlowSpeed;
				onThrust = false;	
			}
			
		}
		
		if( (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift)) && onThrust)
		{
			Move_360.thrustSpeed = defaultSlowSpeed;
			onThrust = false;
		}
	}
}
