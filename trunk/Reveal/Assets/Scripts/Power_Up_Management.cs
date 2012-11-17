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
	public static float yInc = 0;

	
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
	
	public Texture2D put_Juice;
	public static bool doThis_Juice = false;
	
	public Texture2D put_EcoBoost;
	public static bool doThis_EcoBoost = false;
	
	public Texture2D put_Aura;
	public static bool doThis_Aura = false;
	
	public Texture2D put_SpotLight;
	public static bool doThis_SpotLight= false;	
	
	public Texture2D put_Nitro;
	public static bool doThis_Nitro= false;	
	
	public Texture2D put_Live;
	public static bool doThis_Live= false;	
	// Use this for initialization
	void Start () 
	{
		pu_Juice_Invoke = false;
		pu_EcoBoost_Invoke = false;
		pu_Aura_Invoke = false;
		pu_Aura_Effect = false;
		pu_SpotLight_Effect = false;
		pu_SpotLight_Invoke = false;
		//pu_ExtraLife(); // An extra life is given at start of a level?
		doThis_Juice = false;
		doThis_EcoBoost = false;
		doThis_Aura = false;
		doThis_SpotLight= false;	
		doThis_Nitro= false;
		doThis_Live= false;	
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}
	void OnGUI()
	{
		if(doThis_Juice)
		{
			yInc += 15f * Time.deltaTime;
			Rect chk = new Rect(Screen.width/2 - put_Juice.width/2 + Screen.width*0.02f,
				Screen.height/2 - put_Juice.height/2 - Screen.height*0.03f - yInc,
				put_Juice.width,
				put_Juice.height);	
			GUI.Label (chk,put_Juice);
			
			if(yInc > 100)
				doThis_Juice = false;
		}
		if(doThis_EcoBoost)
		{
			yInc += 15f * Time.deltaTime;
			Rect chk = new Rect(Screen.width/2 - put_EcoBoost.width/2 + Screen.width*0.02f,
				Screen.height/2 - put_EcoBoost.height/2 - Screen.height*0.03f - yInc,
				put_EcoBoost.width,
				put_EcoBoost.height);	
			GUI.Label (chk,put_EcoBoost);
			
			if(yInc > 100)
				doThis_EcoBoost = false;
		}
		if(doThis_Aura)
		{
			yInc += 15f * Time.deltaTime;
			Rect chk = new Rect(Screen.width/2 - put_Aura.width/2 + Screen.width*0.02f,
				Screen.height/2 - put_Aura.height/2 - Screen.height*0.03f - yInc,
				put_Aura.width,
				put_Aura.height);	
			GUI.Label (chk,put_Aura);
			
			if(yInc > 100)
				doThis_Aura = false;
		}
		if(doThis_SpotLight)
		{
			yInc += 15f * Time.deltaTime;
			Rect chk = new Rect(Screen.width/2 - put_SpotLight.width/2 + Screen.width*0.02f,
				Screen.height/2 - put_SpotLight.height/2 - Screen.height*0.03f - yInc,
				put_SpotLight.width,
				put_SpotLight.height);	
			GUI.Label (chk,put_SpotLight);
			
			if(yInc > 100)
				doThis_Juice = false;
		}
		if(doThis_Nitro)
		{
			yInc += 15f * Time.deltaTime;
			Rect chk = new Rect(Screen.width/2 - put_Nitro.width/2 + Screen.width*0.02f,
				Screen.height/2 - put_Nitro.height/2 - Screen.height*0.03f - yInc,
				put_Nitro.width,
				put_Nitro.height);	
			GUI.Label (chk,put_Nitro);
			
			if(yInc > 100)
				doThis_Juice = false;
		}
		if(doThis_Live)
		{
			yInc += 15f * Time.deltaTime;
			Rect chk = new Rect(Screen.width/2 - put_Live.width/2 + Screen.width*0.02f,
				Screen.height/2 - put_Live.height/2 - Screen.height*0.03f - yInc,
				put_Live.width,
				put_Live.height);	
			GUI.Label (chk,put_Live);
			
			if(yInc > 100)
				doThis_Live = false;
		}

	}
	// Get's passed from powerup GameObjects
	public static void CallValue(int i)
	{
		// Apparently you need an object reference when calling
		// non-static functions from a static function.
		Power_Up_Management pumgt = new Power_Up_Management();
		yInc = 0;
		
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
	}
	public void pu_ExtraLife() //works
	{
		yInc = 0;
		doThis_Live = true;
		Manage_Game.numOfLives++;
	}
	public void pu_Nitro() //works
	{
		yInc = 0;
		doThis_Nitro = true;
		tempPuNitro = Manage_Game.playerBoostCost;
		Manage_Game.playerBoostCost = 0.0f;
		pu_Nitro_Invoke = true;
	}
	public void pu_TriBeam()
	{
	}
	public void pu_Energizer()
	{
	}
	public void pu_Rocket()
	{
	}
	public void pu_Aura() //works
	{
		yInc = 0;
		doThis_Aura = true;
		pu_Aura_Invoke = true;
		pu_Aura_Effect = true;
	}
	public void pu_Spotlight() //works
	{
		yInc = 0;
		doThis_SpotLight = true;
		pu_SpotLight_Effect = true;	
	}
	public void pu_BeamCannon()
	{;
	}
	public void pu_BeamGatling()
	{
		tempBeamGatling = Manage_Game.helixCost;
		Manage_Game.helixCost /= 2;		
	}
	public void pu_EcoBoost() //works
	{
		yInc = 0;
		doThis_EcoBoost = true;
		tempEcoBoost = Manage_Game.playerBoostCost;
		Manage_Game.playerBoostCost /= 2;
		pu_EcoBoost_Invoke = true;
	}
	public void pu_Juice() //works
	{
		yInc = 0;
		doThis_Juice = true;
		
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
	
	void applyFloatingText(bool doIt, Texture2D texture, float yIncrementer)
	{

	}
}
