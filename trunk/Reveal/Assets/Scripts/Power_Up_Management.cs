using UnityEngine;
using System.Collections;

public class Power_Up_Management : MonoBehaviour {
	
	public enum PowerupType
	{
		PrismCell=1,
		ExtraLife,
		Nitro,
		TriBeam,
		Energizer,
		Rocket,
		Aura,
		Spotlight,
		BeamCannon,
		BeamGatling,
		EcoBoost,
		Juice
	}
	
	public static float tempPuNitro;
	public static float tempPuJuice;
	public static bool pu_Juice_Invoke = false;
	public static bool pu_EcoBoost_Invoke = false;
	public static bool pu_Aura_Invoke = false;
	public static bool pu_Aura_Effect = false;
	public static bool pu_SpotLight_Effect = false;
	public static bool pu_SpotLight_Invoke = false;
	public static bool pu_Nitro_Invoke = false;
	
	public static float tempEcoBoost;
	
	int tempBeamGatling;
	
	public static bool testThisShit = false;
	// Use this for initialization
	void Start () 
	{
		pu_Juice_Invoke = false;
		pu_EcoBoost_Invoke = false;
		pu_Aura_Invoke = false;
		pu_Aura_Effect = false;
		pu_SpotLight_Effect = false;
		pu_SpotLight_Invoke = false;
		pu_ExtraLife(); // An extra life is given at start of a level?
	}
	
	// Update is called once per frame
	void Update () 
	{
		/*
		if(Manage_Game.lightCount < 3)
		{
			pu_BeamGatlingDisable();
			pu_EcoBoostDisable();
		}*/	
	}
	
	// Get's passed from powerup GameObjects
	public static void CallValue(int i)
	{
		// Apparently you need an object reference when calling
		// non-static functions from a static function.
		Power_Up_Management pumgt = new Power_Up_Management();
		
		switch(i)
		{
		case (int) PowerupType.PrismCell:
			pumgt.pu_PrismCell();
			break;
		case (int) PowerupType.ExtraLife:
			pumgt.pu_ExtraLife();
			break;
		case (int) PowerupType.Nitro:
			pumgt.pu_Nitro();
			break;
		case (int) PowerupType.TriBeam:
			pumgt.pu_TriBeam();
			break;
		case (int) PowerupType.Energizer:
			pumgt.pu_Energizer();
			break;
		case (int) PowerupType.Rocket:
			pumgt.pu_Rocket(); //pause it
			break;
		case (int) PowerupType.Aura:
			pumgt.pu_Aura();
			break;
		case (int) PowerupType.Spotlight:
			pumgt.pu_Spotlight();
			break;
		case (int) PowerupType.BeamCannon:
			pumgt.pu_BeamCannon();
			break;
		case (int) PowerupType.BeamGatling:
			pumgt.pu_BeamGatling();
			break;
		case (int) PowerupType.EcoBoost:
			pumgt.pu_EcoBoost();
			break;
		case (int) PowerupType.Juice:
			pumgt.pu_Juice();
			break;
		default:
			Debug.Log("Error: Powerup_Up_Management.cs: Invalid Powerup Enumeration!");
			break;
		}
	}
	
	// Powerup functions
	public void pu_PrismCell()
	{
		Debug.Log("PrismCell");
	}
	public void pu_ExtraLife() //works
	{
		Debug.Log("ExtraLife");
		Manage_Game.numOfLives++;
	}
	public void pu_Nitro() //works
	{
		Debug.Log("Nitro");
		tempPuNitro = Manage_Game.playerBoostCost;
		Manage_Game.playerBoostCost = 0.0f;
		pu_Nitro_Invoke = true;
	}
	public void pu_TriBeam()
	{
		Debug.Log("TriBeam");
	}
	public void pu_Energizer()
	{
		Debug.Log("Energizer");
	}
	public void pu_Rocket()
	{
		Debug.Log("Rocket");
	}
	public void pu_Aura() //works
	{
		Debug.Log("Aura");
		pu_Aura_Invoke = true;
		pu_Aura_Effect = true;
	}
	public void pu_Spotlight() //works
	{
		Debug.Log("Spotlight");
		pu_SpotLight_Effect = true;
		
	}
	public void pu_BeamCannon()
	{
		Debug.Log("BeamCannon");
	}
	public void pu_BeamGatling()
	{
		Debug.Log("BeamGatling");
		tempBeamGatling = Manage_Game.helixCost;
		Manage_Game.helixCost /= 2;		
	}
	public void pu_EcoBoost() //works
	{
		Debug.Log("EcoBoost");
		tempEcoBoost = Manage_Game.playerBoostCost;
		Manage_Game.playerBoostCost /= 2;
		pu_EcoBoost_Invoke = true;
	}
	public void pu_Juice() //works
	{
		Debug.Log("Juice");
		tempPuJuice = Manage_Game.lightRegen;
		if(Manage_Game.lightRegen ==0)
			Manage_Game.lightRegen = 2.0f;	
		Manage_Game.lightRegen *= 2;
		pu_Juice_Invoke = true;
	}
	
	/* --------------------------------------------------------------------
	 * DISABLE FUNCTIONS OVER TIME
	 * --------------------------------------------------------------------*/
	public void pu_NitroDisable()
	{
		Manage_Game.playerBoostCost = tempPuNitro;
	}
	public void pu_JuiceDisable()
	{
		//Manage_Game.lightRegen = tempPuJuice;
	}
	public void pu_BeamGatlingDisable()
	{
		Manage_Game.helixCost = tempBeamGatling;	
	}

}
