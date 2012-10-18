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
	public GameObject ignitionParticles;
	
	private bool activated;
	private bool isFlickeringQuickly = false;
	
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
			renderer.light.color -= Color.white / 2.0f * Time.deltaTime;
			renderer.material.color -= Color.grey / 2.0f * Time.deltaTime;
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
			Instantiate(ignitionParticles, transform.position, transform.rotation);
			
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
			//renderer.material = matDim;
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
			renderer.material = matBright;
	}
	
	void FlickerSlowlyOff()
	{
		if(!isFlickeringQuickly && activated)
			renderer.material = matDim;
	}
	
	void FlickerQuicklyOn()
	{
		if(activated)
			renderer.material = matBright;
	}
	
	void FlickerQuicklyOff()
	{
		if(activated)
			renderer.material = matDim;
	}
	
}
