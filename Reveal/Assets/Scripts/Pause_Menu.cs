using UnityEngine;
using System.Collections;

public class Pause_Menu : MonoBehaviour {
	public static bool isPaused = false;
	public const int NUM_SELECTIONS = 3;
	public static int selection = 1;
	public Texture2D pauseGUI1;
	public Texture2D pauseGUI2;
	public Texture2D pauseGUI3;
	
	public Texture2D blackTile;
	private Texture2D pauseCurrent;
	
	public GameObject jinglePause;
	private GameObject jinglePlayerPause;
	private bool jingleAlreadyPlayed = false;
	
	// Use this for initialization
	void Start () 
	{
		jinglePlayerPause = Instantiate(jinglePause) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Escape) && !isPaused && !Manage_Game.gameOver)
		{
			Time.timeScale = 0.0f;	
			isPaused = true;
			Play_Sound_On_Arrows.CanDo = true;
			Play_Sound_On_Enter.CanDo = true;
			if(jingleAlreadyPlayed == false)
			{
				jingleAlreadyPlayed = true;
				jinglePlayerPause.audio.Play();
				Invoke("AllowJingleAgain", 0.25f);
			}
		}
		else if(Input.GetKeyDown (KeyCode.Escape) && isPaused)
		{
			Time.timeScale = 1.0f;
			isPaused = false;
			Play_Sound_On_Arrows.CanDo = false;
			Play_Sound_On_Enter.CanDo = false;
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
			Play_Sound_On_Arrows.CanDo = false;
			Play_Sound_On_Enter.CanDo = false;
			switch(selection)
			{
				case 1:
					isPaused = false;
					Time.timeScale = 1.0f;
					break;
				case 2:
					isPaused = false;
					Manage_Game.infiniteLives = false;
					Time.timeScale = 1.0f;
					Play_Sound_On_Arrows.CanDo = true;
					Play_Sound_On_Enter.CanDo = true;
					Application.LoadLevel("Intro");
					break;
				case 3:
					Application.Quit();
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
		else if(selection == 3)
			pauseCurrent = pauseGUI3;
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
	
	void AllowJingleAgain()
	{
		jingleAlreadyPlayed = false;
	}
}
