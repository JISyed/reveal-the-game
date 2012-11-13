using UnityEngine;
using System.Collections;

public class Player_Boost : MonoBehaviour {
	
	public static bool onThrust = false; // True if player is boosting
	public static bool boostEffectEnabled = false;
	
	public static bool onBreak = false;
	
	public float boostMultiplier = 2.5f;
	public float breakMultiplier = 0.25f;
	public float defaultSlowSpeed = 700.0f;
	
	private ParticleSystem boostParticles;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Fire2 is defined in InputManager
		if(Input.GetButtonDown("Fire2"))
		{
			if(!onThrust)
			{
				Move_360.thrustSpeed *= boostMultiplier;
				onThrust = true;
			}
			
			if(Manage_Game.lightCount <= 0)
			{
				Move_360.thrustSpeed = defaultSlowSpeed;
				onThrust = false;
				boostEffectEnabled = false;
				gameObject.audio.Stop();
				gameObject.audio.time = 0.0f;
			}
			
			if(boostEffectEnabled)
			{
				gameObject.audio.Play();
			}
			else
			{
				gameObject.audio.Stop();
				gameObject.audio.time = 0.0f;
			}
			
		}
		
		if(Input.GetButtonUp("Fire2"))
		{
			gameObject.audio.Stop();
			gameObject.audio.time = 0.0f;
			boostEffectEnabled = true;
			
			if (onThrust)
			{
				Move_360.thrustSpeed = defaultSlowSpeed;
				onThrust = false;
				gameObject.audio.Stop();
				gameObject.audio.time = 0.0f;
			}
		}
		
		if(!onThrust)
		{
			gameObject.audio.Stop();
		}
		
		//BREAK WHERES THE BREAK!?
		if(Input.GetKeyDown (KeyCode.LeftControl) || Input.GetKeyDown (KeyCode.RightControl))
		{
			if(!onBreak)
			{
				Move_360.thrustSpeed *= breakMultiplier;
				onBreak = true;
			}
			if(Manage_Game.lightCount <= 0)
			{
				Move_360.thrustSpeed = defaultSlowSpeed;
				onBreak = false;
			}
			
		}
		if(Input.GetKeyUp (KeyCode.LeftControl) || Input.GetKeyDown (KeyCode.RightControl))
		{
			if(onBreak)
			{
				Move_360.thrustSpeed = defaultSlowSpeed;
				onBreak = false;
			}
		}
		
		
	}
}
