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
	
	public AudioClip sndExtraLife;
	public AudioClip sndGeneric;
	
	private int audioIndex; // 0 for generic sounds; 1 for extralife;
	
	public Power_Up_Management.PowerupType thePowerup;
	
	// Use this for initialization
	void Start () 
	{
		// Assign material
		switch((int) thePowerup)
		{
		case (int) Power_Up_Management.PowerupType.PrismCell:
			renderer.material = matPrismCell;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.ExtraLife:
			renderer.material = matExtraLife;
			audioIndex = 1;
			break;
		case (int) Power_Up_Management.PowerupType.Nitro:
			renderer.material = matNitro;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.TriBeam:
			renderer.material = matTriBeam;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.Energizer:
			renderer.material = matEnergizer;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.Rocket:
			renderer.material = matRocket;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.Aura:
			renderer.material = matAura;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.Spotlight:
			renderer.material = matSpotlight;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.BeamCannon:
			renderer.material = matBeamCannon;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.BeamGatling:
			renderer.material = matBeamGatling;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.EcoBoost:
			renderer.material = matEcoBoost;
			audioIndex = 0;
			break;
		case (int) Power_Up_Management.PowerupType.Juice:
			renderer.material = matJuice;
			audioIndex = 0;
			break;
		default:
			Debug.Log("Error: Collide_with_Powerups.cs: Invalid Powerup Enumeration!");
			audioIndex = 0;
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
			if(audioIndex == 0)
				AudioSource.PlayClipAtPoint(sndGeneric, other.transform.position);
			else if(audioIndex == 1)
				AudioSource.PlayClipAtPoint(sndExtraLife, other.transform.position);
			Power_Up_Management.CallValue((int)thePowerup);
		}
		
	}
	
}
