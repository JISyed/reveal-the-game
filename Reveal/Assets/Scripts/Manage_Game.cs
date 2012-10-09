// Credit to CookingWithUnity Tutorials.
using UnityEngine;
using System.Collections;

public class Manage_Game : MonoBehaviour {
	
	////////////////////////
	// Variables
	////////////////////////
	
	// Static means shared across instances of GameManager GameObject
	// CANNOT be adjusted in Unity Editor!!!!
	public static int numOfLives;
	public static bool gameOver = false;
	public static bool winLevel = false;
	public static float lightCount = 100;
	public static int helixCost = 10;
	
	// Public variables editable in Editor
	public int lives = 1;
	public Texture2D imgGameOver;
	public Texture2D imgYouWin;
	
	public Texture2D lightBar;
	public Texture2D lightMeter;
	public Texture2D livesImage;
	
	////////////////////////
	// Start Event
	////////////////////////
	
	// Use this for initialization
	void Start () 
	{
		// 'lives' is set in Editor.
		// 'numOfLives' can be accessed by scripts via "Manage_Game.numOfLives".
		numOfLives = lives;
		audio.Play ();
		audio.volume *= 2;
	}
	
	////////////////////////
	// Update Event
	////////////////////////
	
	// Update is called once per frame
	void Update () 
	{
		// Press Enter to reset level IF Game Over
		if(gameOver)
		{
			if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7"))
			{
				gameOver = false;
				numOfLives = lives; // Reset lives
				lightCount = 100;
				Player_Boost.onThrust = false;
				Application.LoadLevel("Intro");
			}
		}
		
		

		// Upon no lives it is Game Over
		if(numOfLives <= 0)
		{
			gameOver = true;
			lightCount = 100;
			Player_Boost.onThrust = false;
		}
		
		// Press enter to restart the level if you won
		if(winLevel)
		{
			lightCount = 100;
			Player_Boost.onThrust = false;
			
			if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7"))
			{
				Move_360.thrustSpeed = 700f;
				winLevel = false;
				numOfLives = lives; // Reset lives
				lightCount = 100;
				Application.LoadLevel("Intro");
			}
		}
		
		lightCount += (5 * Time.deltaTime);
		
		if(Player_Boost.onThrust)
			lightCount -= (10 * Time.deltaTime);
		
		if(lightCount > 100)
			lightCount = 100;
		
		if(lightCount < 0)
			lightCount = 0;
		
		if(lightCount == 0)
		{
			Move_360.thrustSpeed = 700f;
			Player_Boost.onThrust = false;	
		}
		//Debug.Log ((int)lightCount);
	}
	
	////////////////////////
	// OnGUI Event
	////////////////////////
	
	// Used to draw the GUI
	void OnGUI()
	{

		//Draw Light Bar
		
		//lightMeter width = 128
		//lightCanvas width = 256
		float lVal = 250/100;
		GUI.BeginGroup (new Rect(50, 410, 250, 55));
			GUI.DrawTexture(new Rect(0,0,(float)lightCount*(lVal),55),lightMeter,ScaleMode.StretchToFill);
			GUI.DrawTexture (new Rect(0,0, 200, 55),lightBar, ScaleMode.StretchToFill);		
		GUI.EndGroup();
		
		
		GUI.BeginGroup (new Rect(Screen.width-180, 410, 150, 50));
			for(int i = 0; i < numOfLives; i++)
			{
				GUI.DrawTexture (new Rect( (100-i*50),0,50,50),livesImage);
			}
		GUI.EndGroup ();
		//Rect lightCanvas = new Rect(450, 400, lightBar.width, lightBar.height);
		//GUI.Label(lightCanvas, lightBar);
		
		// Draw game over display
		if(gameOver)
		{
			Rect splashCanvas = new Rect((Screen.width/2.0f) - (imgGameOver.width/2.0f),
										 (Screen.height/2.0f) - (imgGameOver.height/2.0f), 
				                         imgGameOver.width, 
				                         imgGameOver.height);
			GUI.Label(splashCanvas, imgGameOver);
		}
		
		// Draw winning display
		if(winLevel)
		{
			Rect splashCanvas = new Rect((Screen.width/2.0f) - (imgYouWin.width/2.0f),
									     (Screen.height/2.0f) - (imgYouWin.height/2.0f), 
									     imgYouWin.width, 
										 imgYouWin.height);
			GUI.Label(splashCanvas, imgYouWin);
		}
	}
	
	////////////////////////
	// OnDrawGizmos Event
	////////////////////////
	
	// Only to have a Gizmo manifested in the Editor. Does not appear in game.
	void OnDrawGizmos() {}
}
