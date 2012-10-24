using UnityEngine;
using System.Collections;

public class Change_Beacon_State : MonoBehaviour 
{	
	public Material matDim;
	public Material matBright;
	public GameObject flickeringSound;
	public float deactivationTimeInSeconds = 5.0f;
	
	public bool dimLightEnable = false;
	public bool callThisFunctionOnce = true;
	public Color originalLightColor;
	public Material originalMaterial;
	public GameObject ingPrt_White;
	public GameObject ingPrt_Red;
	public GameObject ingPrt_Green;
	public GameObject ingPrt_Blue;
	
	private bool activated;
	private bool isFlickeringQuickly = false;
	private bool lightDimmingColorSet = false;
	
	// Use this for initialization
	void Start () {

		activated = false;
		renderer.material = matDim;
		light.enabled = false;
		originalLightColor = renderer.light.color;
		originalMaterial = renderer.material;
	}
	
	
	
	// Update is called once per frame
	void Update () {
		if(dimLightEnable)
		{
			// Dim the light's color depending on color state
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.white)
			{
				if(lightDimmingColorSet == false)
				{
					lightDimmingColorSet = true;
					renderer.material.color = Manage_Game.col_white;
					light.color = Manage_Game.col_white;
				}
				renderer.light.color -= Color.white / 2.0f * Time.deltaTime;
				renderer.material.color -= Color.grey / 2.0f * Time.deltaTime;
			}
			else if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.red)
			{
				if(lightDimmingColorSet == false)
				{
					lightDimmingColorSet = true;
					renderer.material.color = Manage_Game.col_red;
					light.color = Manage_Game.col_red;
				}
				renderer.light.color -= Color.red / 2.0f * Time.deltaTime;
				renderer.material.color -= Color.red / 2.0f * Time.deltaTime;
			}
			else if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.green)
			{
				if(lightDimmingColorSet == false)
				{
					lightDimmingColorSet = true;
					renderer.material.color = Manage_Game.col_green;
					light.color = Manage_Game.col_green;
				}
				renderer.light.color -= Color.green / 2.0f * Time.deltaTime;
				renderer.material.color -= Color.green / 2.0f * Time.deltaTime;
			}
			else if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.blue)
			{
				if(lightDimmingColorSet == false)
				{
					lightDimmingColorSet = true;
					renderer.material.color = Manage_Game.col_blue;
					light.color = Manage_Game.col_blue;
				}
				renderer.light.color -= Color.blue / 2.0f * Time.deltaTime;
				renderer.material.color -= Color.blue / 2.0f * Time.deltaTime;
			}
			
			// Stop dimming
			if(callThisFunctionOnce)
			{
				callThisFunctionOnce = false;
				Invoke ("When2SecondsPass", 2.0f);
			}
		}
		
	}
	
	//When 2 seconds pass
	void When2SecondsPass()
	{
		renderer.light.color = originalLightColor;
		renderer.material = matDim;
		callThisFunctionOnce = true;
		dimLightEnable = false;
		light.enabled = false;
		activated = false;
		lightDimmingColorSet = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject); // Suppose to destroy lightwaves

		// Change to state of the beacon
		if (!activated)
		{
			audio.Play ();
			activated = true;
			
			renderer.material = matBright;
			light.enabled = true;
			
			// Change state of colors depending on color of beam
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.white)
			{
				renderer.material.color = Manage_Game.col_white;
				light.color = Manage_Game.col_white;
				Instantiate(ingPrt_White, transform.position, transform.rotation);
			}
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.red)
			{
				renderer.material.color = Manage_Game.col_red;
				light.color = Manage_Game.col_red;
				Instantiate(ingPrt_Red, transform.position, transform.rotation);
			}
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.green)
			{
				renderer.material.color = Manage_Game.col_green;
				light.color = Manage_Game.col_green;
				Instantiate(ingPrt_Green, transform.position, transform.rotation);
			}
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.blue)
			{
				renderer.material.color = Manage_Game.col_blue;
				light.color = Manage_Game.col_blue;
				Instantiate(ingPrt_Blue, transform.position, transform.rotation);
			}
			
			// It's only activated for a certain time
			Invoke("DeactivateBeacon", deactivationTimeInSeconds);
			
			// Make beacon flicker in last 3 seconds of activation.
			if(deactivationTimeInSeconds > 3)
			{
				// Invoke in last 3 seconds
				Invoke("FlickerSlowly", deactivationTimeInSeconds - 3.0f);
				Invoke("FlickerQuickly", deactivationTimeInSeconds - 1.0f);
			}
			// 
			else if(deactivationTimeInSeconds < 3 && deactivationTimeInSeconds > 1)
			{
				// Invoke immediatly
				Invoke("FlickerSlowly", 0.0f);
				Invoke("FlickerQuickly", deactivationTimeInSeconds - 1.0f);
			}	
			else
			{
				Invoke("FlickerQuickly", 0.0f);
			}
		}
	}
	
	void FlickerDim()
	{

		dimLightEnable = true;
	}
	
	void DeactivateBeacon()
	{
		if(activated)
		{
			isFlickeringQuickly = false;		
			Invoke ("FlickerDim",0.0f);
			//;
		}
	}
	
	// Assumes to flicker for 3 seconds!
	
	// Flickers slowly for 2 seconds
	void FlickerSlowly()
	{
		// Play flickering sound
		Instantiate(flickeringSound, 
			        gameObject.transform.position, 
			        gameObject.transform.rotation);
		Invoke("FlickerSlowlyOff", 0.0f);
		Invoke("FlickerSlowlyOn", 0.25f);
		Invoke("FlickerSlowlyOff", 0.5f);
		Invoke("FlickerSlowlyOn", 0.75f);
		Invoke("FlickerSlowlyOff", 1.0f);
		Invoke("FlickerSlowlyOn", 1.25f);
		Invoke("FlickerSlowlyOff", 1.5f);
		Invoke("FlickerSlowlyOn", 1.75f);
		Invoke("FlickerSlowlyOff", 2.0f);
		Invoke("FlickerSlowlyOn", 2.25f);
		Invoke("FlickerSlowlyOff", 2.5f);
		Invoke("FlickerSlowlyOn", 2.75f);
	}
	
	// Flickers quickly for 1 second
	void FlickerQuickly()
	{
		isFlickeringQuickly = true;
		
		Invoke("FlickerQuicklyOff", 0.0f);
		Invoke("FlickerQuicklyOn", 0.125f);
		Invoke("FlickerQuicklyOff", 0.25f);
		Invoke("FlickerQuicklyOn", 0.375f);
		Invoke("FlickerQuicklyOff", 0.5f);
		Invoke("FlickerQuicklyOn", 0.625f);
		Invoke("FlickerQuicklyOff", 0.75f);
		Invoke("FlickerQuicklyOn", 0.875f);
	}
	
	void FlickerSlowlyOn()
	{
		if(!isFlickeringQuickly && activated)
		{
			renderer.material = matBright;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.white)
				renderer.material.color = Manage_Game.col_white;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.red)
				renderer.material.color = Manage_Game.col_red;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.green)
				renderer.material.color = Manage_Game.col_green;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.blue)
				renderer.material.color = Manage_Game.col_blue;
		}
	}
	
	void FlickerSlowlyOff()
	{
		if(!isFlickeringQuickly && activated)
		{
			renderer.material = matDim;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.white)
				renderer.material.color = new Color (0.4f, 0.4f, 0.4f);
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.red)
				renderer.material.color = new Color (0.4f, 0.0f, 0.0f);
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.green)
				renderer.material.color = new Color (0.0f, 0.4f, 0.0f);
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.blue)
				renderer.material.color = new Color (0.0f, 0.0f, 0.4f);
		}
	}
	
	void FlickerQuicklyOn()
	{
		if(activated)
		{
			renderer.material = matBright;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.white)
				renderer.material.color = Manage_Game.col_white;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.red)
				renderer.material.color = Manage_Game.col_red;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.green)
				renderer.material.color = Manage_Game.col_green;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.blue)
				renderer.material.color = Manage_Game.col_blue;
		}
	}
	
	void FlickerQuicklyOff()
	{
		if(activated)
		{
			renderer.material = matDim;
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.white)
				renderer.material.color = new Color (0.4f, 0.4f, 0.4f);
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.red)
				renderer.material.color = new Color (0.4f, 0.0f, 0.0f);
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.green)
				renderer.material.color = new Color (0.0f, 0.4f, 0.0f);
			
			if(Move_Lightwave.currentColor == (int) Manage_Game.Colors.blue)
				renderer.material.color = new Color (0.0f, 0.0f, 0.4f);
		}
	}
	
}
