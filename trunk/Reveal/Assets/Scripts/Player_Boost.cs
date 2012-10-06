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
		
		// Fire2 is defined in InputManager
		if(Input.GetButtonDown("Fire2"))
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
		
		if(Input.GetButtonUp("Fire2") && onThrust)
		{
			Move_360.thrustSpeed = defaultSlowSpeed;
			onThrust = false;
		}
	}
}
