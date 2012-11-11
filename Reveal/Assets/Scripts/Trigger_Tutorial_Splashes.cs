using UnityEngine;
using System.Collections;

public class Trigger_Tutorial_Splashes : MonoBehaviour {
	
	public Texture2D tutorialSplash;
	
	private bool isPaused = false;
	private bool triggerAlreadyPassed = false;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isPaused)
		{
			Time.timeScale = 0.0f;
		}
		
		if(isPaused && Input.GetKeyDown(KeyCode.Return))
		{
			isPaused = false;
			Time.timeScale = 1.0f;
		}
	}
	
	// GUI stuff
	void OnGUI()
	{
		if(isPaused)
		{
			GUI.BeginGroup (new Rect(Screen.width/2f - tutorialSplash.width/2f, Screen.height/2f - tutorialSplash.height/2f, tutorialSplash.width, tutorialSplash.height));
			GUI.DrawTexture(new Rect(0,0,tutorialSplash.width, tutorialSplash.height), tutorialSplash, ScaleMode.ScaleToFit);
			GUI.EndGroup ();
		}
	}
	
	// Tirgger stuff
	void OnTriggerEnter(Collider other)
	{
		if(triggerAlreadyPassed == false)
		{
			triggerAlreadyPassed = true;
			isPaused = true;
		}
	}
}
