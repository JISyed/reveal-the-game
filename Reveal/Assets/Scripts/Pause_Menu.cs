using UnityEngine;
using System.Collections;

public class Pause_Menu : MonoBehaviour {
	public static bool isPaused = false;
	public const int NUM_SELECTIONS = 2;
	public static int selection = 1;
	public Texture2D pauseGUI1;
	public Texture2D pauseGUI2;
	public Texture2D blackTile;
	private Texture2D pauseCurrent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape) && !isPaused && !Manage_Game.gameOver)
		{
			Time.timeScale = 0.0f;	
			isPaused = true;
		}
		else if(Input.GetKeyDown (KeyCode.Escape) && isPaused)
		{
			Time.timeScale = 1.0f;
			isPaused = false;
		}
		
		if(isPaused && Input.GetKeyDown (KeyCode.DownArrow))
		{
			selection++;
			if(selection > NUM_SELECTIONS)
				selection = 1;
		}
		if(isPaused && Input.GetKeyDown (KeyCode.UpArrow))
		{
			selection--;
			if(selection < 1)
				selection = NUM_SELECTIONS;
		}
		
		if(isPaused && Input.GetKeyDown (KeyCode.Return))
		{
			switch(selection)
			{
				case 1:
					isPaused = false;
					Time.timeScale = 1.0f;
					break;
				case 2:
					isPaused = false;
					Time.timeScale = 1.0f;
					Application.LoadLevel("Intro");
					break;
				default:
					isPaused = false;
					break;
			}
		}
	}
	
	void OnGUI()
	{
		if(selection == 1)
			pauseCurrent = pauseGUI1;
		else if(selection == 2)
			pauseCurrent = pauseGUI2;
		
		if(isPaused)
		{
			
			Rect splashCanvas = new Rect((Screen.width/2.0f) - (pauseCurrent.width/2.0f),
										 (Screen.height/2.0f) - (pauseCurrent.height/2.0f), 
				                         pauseCurrent.width, 
				                         pauseCurrent.height);
			
			Color temp = GUI.color;
			
			//Rect blackCanvas = new Rect(0,0,5000,50000);
			//temp.a = 0.9f;
			//GUI.color = temp;
			GUI.DrawTexture (new Rect(0,0, 5000, blackTile.height), blackTile,ScaleMode.StretchToFill);
			//GUI.Label (blackCanvas, blackTile);
			
			//temp.a = 1.0f;
			GUI.color = temp;
			GUI.Label(splashCanvas, pauseCurrent);
			
		}
		
		if(Manage_Game.gameOver)
		{
			GUI.DrawTexture (new Rect(0,0, 5000, blackTile.height), blackTile,ScaleMode.StretchToFill);	
		}
	}
}
