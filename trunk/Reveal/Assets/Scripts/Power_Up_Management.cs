using UnityEngine;
using System.Collections;

public class Power_Up_Management : MonoBehaviour {
	
	float tempPuNitro;
	float tempPuJuice;
	float tempEcoBoost;
	int tempBeamGatling;
	
	// Use this for initialization
	void Start () 
	{
		pu_ExtraLife(); // An extra life is given at start of a level?
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Manage_Game.lightCount < 3)
		{
			pu_BeamGatlingDisable();
			pu_EcoBoostDisable();
		}	
	}
	
	// Get's passed from powerup GameObjects
	void CallValue(int i)
	{
		switch(i)
		{
		case 1:
			pu_PrismCell();
			break;
		case 2:
			pu_ExtraLife();
			break;
		case 3:
			pu_Nitro();
			break;
		case 4:
			pu_TriBeam();
			break;
		case 5:
			pu_Energizer();
			break;
		case 6:
			pu_Rocket(); //pause it
			break;
		case 7:
			pu_Aura();
			break;
		case 8:
			pu_Spotlight();
			break;
		case 9:
			pu_BeamCannon();
			break;
		case 10:
			pu_BeamGatling();
			break;
		case 11:
			pu_EcoBoost();
			break;
		case 12:
			pu_Juice();
			break;
		default:
			pu_Nitro();
			break;
			
		}
	}
	
	// Powerup functions
	void pu_PrismCell()
	{
		
	}
	void pu_ExtraLife()
	{
		Manage_Game.numOfLives++;
	}
	void pu_Nitro()
	{
		tempPuNitro = Manage_Game.playerBoostCost;
		Manage_Game.playerBoostCost = 0.0f;
		Invoke ("pu_NitroDisable", 15.0f);
	}
	void pu_TriBeam()
	{
		
	}
	void pu_Energizer()
	{
		
	}
	void pu_Rocket()
	{
		
	}
	void pu_Aura()
	{
		
	}
	void pu_Spotlight()
	{
		
	}
	void pu_BeamCannon()
	{
		
	}
	void pu_BeamGatling()
	{
		tempBeamGatling = Manage_Game.helixCost;
		Manage_Game.helixCost /= 2;		
	}
	void pu_EcoBoost()
	{
		tempEcoBoost = Manage_Game.playerBoostCost;
		Manage_Game.playerBoostCost /= 2;
	}
	void pu_Juice()
	{
		tempPuJuice = Manage_Game.lightRegen;
		if(Manage_Game.lightRegen ==0)
			Manage_Game.lightRegen = 2.0f;	
		Manage_Game.lightRegen *= 2;
		Invoke ("pu_JuiceDisable", 30.0f);
	}
	
	/* --------------------------------------------------------------------
	 * DISABLE FUNCTIONS OVER TIME
	 * --------------------------------------------------------------------*/
	void pu_NitroDisable()
	{
		Manage_Game.playerBoostCost = tempPuNitro;
	}
	void pu_JuiceDisable()
	{
		Manage_Game.lightRegen = tempPuJuice;
	}
	void pu_BeamGatlingDisable()
	{
		Manage_Game.helixCost = tempBeamGatling;	
	}
	void pu_EcoBoostDisable()
	{
		Manage_Game.playerBoostCost = tempEcoBoost;
	}
}
