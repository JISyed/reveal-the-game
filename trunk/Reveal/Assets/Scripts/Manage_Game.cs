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
	public static int helixCost = 15;
	public static Vector3 startPos;
	public static float respawnTime;
	public static float lightRegen = 4.0f;
	
	public static bool viewCurrentLevelImage = true;
	public static float viewCurrentLevelTime = 3.0f;
	// Public variables editable in Editor
	public float startXPos = 0.0f;
	public float startZPos = 0.0f;
	public int lives = 1;
	public float respawnInSeconds = 3.0f;
	public Texture2D imgGameOver;
	public Texture2D imgYouWin;
	
	public Texture2D lightBar;
	public Texture2D lightMeter;
	public Texture2D livesImage;
	
	public Texture2D currentLevel;
	
	public static bool infiniteLives = false;
	////////////////////////
	// Start Event
	////////////////////////
	
	// Use this for initialization
	void Start () 
	{
		respawnTime = respawnInSeconds;
		startPos.Set(startXPos, 7.25f, startZPos);
		// 'lives' is set in Editor.
		// 'numOfLives' can be accessed by scripts via "Manage_Game.numOfLives".
		numOfLives = lives;
		
		// enable infinite lives if numOfLives == 0
		if(lives == 0)
		{
			numOfLives = 1;
			infiniteLives = true;
		}
		
		audio.Play();
		viewCurrentLevelImage = true;
		Invoke("FadeLevelImageOut", viewCurrentLevelTime);
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
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		
		

		// Upon no lives it is Game Over
		if(numOfLives <= 0 && infiniteLives == false)
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
				
				// Load next level if there is a next level
				if(Application.loadedLevel < Application.levelCount - 1)
				{
					Application.LoadLevel(Application.loadedLevel + 1);
				}
				else
				{
					Application.LoadLevel("Intro");
				}
			}
		}
		
		lightCount += (lightRegen * Time.deltaTime);
		
		if(Player_Boost.onThrust)
			lightCount -= (11 * Time.deltaTime);
		
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
		else if(winLevel)
		{
			Rect splashCanvas = new Rect((Screen.width/2.0f) - (imgYouWin.width/2.0f),
									     (Screen.height/2.0f) - (imgYouWin.height/2.0f), 
									     imgYouWin.width, 
										 imgYouWin.height);
			GUI.Label(splashCanvas, imgYouWin);
		}
		

		//Draw Light Bar
		else
		{
			//lightMeter width = 128
			//lightCanvas width = 256
			float lVal = 250/100;
			GUI.BeginGroup (new Rect(50, Screen.height-65, 250, 55));
				GUI.DrawTexture(new Rect(0,0,(float)lightCount*(lVal),55),lightMeter,ScaleMode.StretchToFill);
				GUI.DrawTexture (new Rect(0,0, 200, 55),lightBar, ScaleMode.StretchToFill);		
			GUI.EndGroup();
		
			if(infiniteLives == false)
			{
				GUI.BeginGroup (new Rect(Screen.width-180, Screen.height-65, 150, 50));
				for(int i = 0; i < numOfLives; i++)
				{
					GUI.DrawTexture (new Rect( (100-i*50),0,50,50),livesImage);
				}
				GUI.EndGroup ();
			}
			
			if(viewCurrentLevelImage)
			{
				GUI.BeginGroup (new Rect((Screen.width/2)-(currentLevel.width/2), Screen.height*0.2f,
					currentLevel.width, currentLevel.height));
					GUI.DrawTexture (new Rect(0,0, currentLevel.width, currentLevel.height/2),currentLevel, ScaleMode.StretchToFill);
				
				GUI.EndGroup();
			}
			//Rect lightCanvas = new Rect(450, 400, lightBar.width, lightBar.height);
			//GUI.Label(lightCanvas, lightBar);
		}
	}
	
	void FadeLevelImageOut()
	{
		viewCurrentLevelImage = false;
	}
}