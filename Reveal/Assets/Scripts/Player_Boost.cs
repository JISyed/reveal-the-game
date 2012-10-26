using UnityEngine;
using System.Collections;

public class Player_Boost : MonoBehaviour {
	
	public static bool onThrust = false; // True if player is boosting
	public static bool boostEffectEnabled = false;
	
	public float boostMultiplier = 2.5f;
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
	}
}
