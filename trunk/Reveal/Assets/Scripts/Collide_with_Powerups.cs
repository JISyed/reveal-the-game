using UnityEngine;
using System.Collections;

public class Collide_with_Powerups : MonoBehaviour {
	
	public Material matAura;
	public Material matBeamCannon;
	public Material matBeamGatling;
	public Material matEcoBoost;
	public Material matEnergizer;
	public Material matExtraLife;
	public Material matJuice;
	public Material matNitro;
	public Material matPrismCell;
	public Material matRocket;
	public Material matSpotlight;
	public Material matTriBeam;
	
	public Power_Up_Management.PowerupType thePowerup;
	
	// Use this for initialization
	void Start () 
	{
		// Assign material
		switch((int) thePowerup)
		{
		case (int) Power_Up_Management.PowerupType.PrismCell:
			renderer.material = matPrismCell;
			break;
		case (int) Power_Up_Management.PowerupType.ExtraLife:
			renderer.material = matExtraLife;
			break;
		case (int) Power_Up_Management.PowerupType.Nitro:
			renderer.material = matNitro;
			break;
		case (int) Power_Up_Management.PowerupType.TriBeam:
			renderer.material = matTriBeam;
			break;
		case (int) Power_Up_Management.PowerupType.Energizer:
			renderer.material = matEnergizer;
			break;
		case (int) Power_Up_Management.PowerupType.Rocket:
			renderer.material = matRocket;
			break;
		case (int) Power_Up_Management.PowerupType.Aura:
			renderer.material = matAura;
			break;
		case (int) Power_Up_Management.PowerupType.Spotlight:
			renderer.material = matSpotlight;
			break;
		case (int) Power_Up_Management.PowerupType.BeamCannon:
			renderer.material = matBeamCannon;
			break;
		case (int) Power_Up_Management.PowerupType.BeamGatling:
			renderer.material = matBeamGatling;
			break;
		case (int) Power_Up_Management.PowerupType.EcoBoost:
			renderer.material = matEcoBoost;
			break;
		case (int) Power_Up_Management.PowerupType.Juice:
			renderer.material = matJuice;
			break;
		default:
			Debug.Log("Error: Collide_with_Powerups.cs: Invalid Powerup Enumeration!");
			break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	// Collision (powerup is a trigger)
	void OnTriggerEnter(Collider other)
	{
		
		if(tag == "Powerup")
		{
			// Handle collisions with powerups
			Destroy(gameObject);
			Power_Up_Management.CallValue((int)thePowerup);
		}
		
	}
	
}
