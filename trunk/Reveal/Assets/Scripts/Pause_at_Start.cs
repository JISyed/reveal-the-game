using UnityEngine;
using System.Collections;

public class Pause_at_Start : MonoBehaviour {
	
	public static bool gameStarted = false;
	
	public Texture2D imgStartScreen;
	
	// Use this for initialization
	void Start () {
		// Pauses the game. I personally don't like this implementation.
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
		// Press enter to start the game
		if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7")) && !gameStarted)
		{
			gameStarted = true;
			Time.timeScale = 1.0f;
		}
	}
	
	// Draw GUI
	void OnGUI()
	{
		if(!gameStarted)
		{
			Rect splashCanvas = new Rect((Screen.width/2.0f) - (imgStartScreen.width/2.0f),
									 	 (Screen.height/2.0f) - (imgStartScreen.height/2.0f), 
										 imgStartScreen.width, 
										 imgStartScreen.height);
			GUI.Label(splashCanvas, imgStartScreen);
		}
	}
}
