using UnityEngine;
using System.Collections;

public class Set_Color_State : MonoBehaviour {

	public string colorToChangeInto;
	
	private bool soundAlreadyPlayed = false;
	private bool matFadingOff = true;
	
	private const float MIN_BRIGHT = 0.45f;
	private const float MAX_BRIGHT = 0.95f;
	private const float FLUX_SPEED = 1.5f;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Fluxuate brightness of material
		if(colorToChangeInto == "Red" || colorToChangeInto == "red")
		{
			if(renderer.material.color.r < MIN_BRIGHT)
			{
				matFadingOff = false;
			}
			if(renderer.material.color.r > MAX_BRIGHT)
			{
				matFadingOff = true;
			}
			
			if(matFadingOff)
			{
				renderer.material.color -= Color.red / FLUX_SPEED * Time.deltaTime;
				renderer.light.color -= Color.red / FLUX_SPEED * Time.deltaTime;
			}
			else
			{
				renderer.material.color += Color.red / FLUX_SPEED * Time.deltaTime;
				renderer.light.color += Color.red / FLUX_SPEED * Time.deltaTime;
			}
		}
		else if(colorToChangeInto == "Green" || colorToChangeInto == "green")
		{

			
			if(renderer.material.color.g < MIN_BRIGHT)
			{
				matFadingOff = false;
			}
			if(renderer.material.color.g > MAX_BRIGHT)
			{
				matFadingOff = true;
			}
			
			if(matFadingOff)
			{
				renderer.material.color -= Color.green / FLUX_SPEED * Time.deltaTime;
				renderer.light.color -= Color.green / FLUX_SPEED * Time.deltaTime;
			}
			else
			{
				renderer.material.color += Color.green / FLUX_SPEED * Time.deltaTime;
				renderer.light.color += Color.green / FLUX_SPEED * Time.deltaTime;
			}
		}
		else if(colorToChangeInto == "Blue" || colorToChangeInto == "blue")
		{
			if(renderer.material.color.b < MIN_BRIGHT)
			{
				matFadingOff = false;
			}
			if(renderer.material.color.b > MAX_BRIGHT)
			{
				matFadingOff = true;
			}
			
			if(matFadingOff)
			{
				renderer.material.color -= Color.blue / FLUX_SPEED * Time.deltaTime;
				renderer.light.color -= Color.blue / FLUX_SPEED * Time.deltaTime;
			}
			else
			{
				renderer.material.color += Color.blue / FLUX_SPEED * Time.deltaTime;
				renderer.light.color += Color.blue / FLUX_SPEED * Time.deltaTime;
			}
		}
		else
		{
			Debug.Log("Invalid string for \"Set_Color_State.colorToChangeInto\"");
		}
	}
	
	// When player hits gem
	void OnTriggerEnter(Collider other)
	{
		if(soundAlreadyPlayed == false)
		{
			soundAlreadyPlayed = true;
			Invoke("AllowSoundToPlayAgain", 4f);
			audio.Play();
		}
		if(!InteractiveTutorial.Prism_Tutorial_Collide && InteractiveTutorial.currentOne == 11)
			InteractiveTutorial.Prism_Tutorial_Collide = true;
		
		if(colorToChangeInto == "Red" || colorToChangeInto == "red")
		{
			Manage_Game.colorState = (int) Manage_Game.Colors.red;
		}
		else if(colorToChangeInto == "Green" || colorToChangeInto == "green")
		{
			Manage_Game.colorState = (int) Manage_Game.Colors.green;
		}
		else if(colorToChangeInto == "Blue" || colorToChangeInto == "blue")
		{
			Manage_Game.colorState = (int) Manage_Game.Colors.blue;
		}
		else
		{
			Debug.Log("Invalid string for \"Set_Color_State.colorToChangeInto\"");
		}
	}
	
	// Enable sounds again
	void AllowSoundToPlayAgain()
	{
		soundAlreadyPlayed = false;
	}
}
