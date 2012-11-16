// Credit to CookingWithUnity Tutorials.
using UnityEngine;
using System.Collections;

public class Manage_Game : MonoBehaviour {
	
	////////////////////////
	// Variables
	////////////////////////
	
	// Static means shared across instances of GameManager GameObject
	// CANNOT be adjusted in Unity Editor!!!!
	public static float playerBoostCost = 11.0f;
	public static int numOfLives;
	public static bool gameOver = false;
	public static bool winLevel = false;
	public static float lightCount = 100;
	public static int helixCost = 10;
	public static Vector3 startPos;
	public static float respawnTime;
	public static float lightRegen = 4.0f;
	public static int difficulty = 1;
	public static bool viewCurrentLevelImage = true;
	public static bool viewCurrentFadeTime = true;
	public static float viewCurrentLevelTime = 5.0f;
	private float viewCurrentLevelImageAlpha = 1.0f;
	
	//Countdown
	public bool WillUseCountDown = true;
	private int NumberCountDownIsOn = 4; //4 or 0, no show, 1-2-3 an image
	public Texture2D CountDown3;
	public Texture2D CountDown2;
	public Texture2D CountDown1;
	public Texture2D CountDownGo;
	private Texture2D CountDownCurrent;
	private float CountDownAlphaGo = 1.0f;
	
	public static bool canMove = true;
	// Public variables editable in Editor
	public float startXPos = 0.0f;
	public float startZPos = 0.0f;
	public int lives = 1;
	public float respawnInSeconds = 3.0f;
	
	//Game Over
	public Texture2D imgGameOver;
	public Texture2D imgGameOverArrow;
	private int GameOverSelect = 1;
	
	public Texture2D imgYouWin;
	
	public Texture2D lightBar;
	public Texture2D lightMeter;
	public Texture2D livesImage;
	
	public Texture2D currentLevel;
	public float levelTextureAlpha = 1.0f;
	public Texture2D checkpoint;
	
	public GameObject jingleGameOver;
	public GameObject jingleWinLevel;
	private bool jingleAlreadyPlayed = false;
	private GameObject jinglePlayerGameOver;
	private GameObject jinglePlayerWinLevel;
	
	public static bool infiniteLives = false;
	private bool toggleGUI = true;
	public enum Colors {white, red, blue, green};
	public static int colorState = (int) Colors.white;
	
	public static bool pu_Aura = false;
	public static bool testBoolean = true;
	public GameObject TB;
	////////////////////////
	// Colors
	////////////////////////
	
	public static Color col_white = new Color(1.0f, 1.0f, 1.0f);
	public static Color col_red = new Color(1.0f, 0.0f, 0.0f);
	public static Color col_green = new Color(0.0f, 1.0f, 0.0f);
	public static Color col_blue = new Color(0.0f, 0.0f, 1.0f);
	public static Color draw_blue = new Color(0.2f, 0.3f, 1.0f); // for blue lightbar
	////////////////////////
	// Start Event
	////////////////////////
	
	// Use this for initialization
	void Start () 
	{
		colorState = (int)Colors.white;
		jinglePlayerGameOver = Instantiate(jingleGameOver) as GameObject;
		jinglePlayerWinLevel = Instantiate(jingleWinLevel) as GameObject;
		
		respawnTime = respawnInSeconds;
		startPos.Set(startXPos, 7.25f, startZPos);
		// 'lives' is set in Editor.
		// 'numOfLives' can be accessed by scripts via "Manage_Game.numOfLives".
		numOfLives = lives;
		InteractiveTutorial.Shooting_Tutorial_Criteria = false;
		//Debug.Log (difficulty);
	
		switch(difficulty)
		{
		case 1:
			lightRegen = 7.0f;
			break;
		case 2:
			lightRegen = 4.0f;
			break;
		case 3:
			lightRegen = 0.0f;
			break;
		default:
			lightRegen = 7.0f;
			break;
		}
		//Debug.Log (lightRegen);
		// enable infinite lives if numOfLives == 0
		if(lives == 0)
		{
			numOfLives = 1;
			infiniteLives = true;
		}
		
		audio.Play();
		viewCurrentLevelImage = true;
		viewCurrentFadeTime = true;
		Invoke("FadeLevelImageOut", viewCurrentLevelTime);
		
		Play_Sound_On_Arrows.CanDo = false;
		Play_Sound_On_Enter.CanDo = false;
		
		if(WillUseCountDown)
		{
			canMove = false;
			Invoke ("CountDown", 2.0f); //3
			Invoke ("CountDown", 3.0f); //2
			Invoke ("CountDown", 4.0f); //1
			Invoke ("CountDown", 5.0f); //Go!
		}
		InteractiveTutorial.Shooting_Tutorial_Criteria = false;
		lightCount = 100;
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
			Play_Sound_On_Arrows.CanDo = true;
			Play_Sound_On_Enter.CanDo = true;
			// Play gameover music
			if(jingleAlreadyPlayed == false)
			{
				audio.Stop();
				jinglePlayerGameOver.audio.Play();
				jingleAlreadyPlayed = true;
			}
			
			if(Input.GetKeyDown (KeyCode.DownArrow))
			{
				GameOverSelect++;
				if(GameOverSelect > 4)
					GameOverSelect = 1;
			}
			if(Input.GetKeyDown (KeyCode.UpArrow))
			{
				GameOverSelect--;
				if(GameOverSelect < 1)
					GameOverSelect = 4;
			}
			// Press enter to reset level
			if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7"))
			{
				if(jinglePlayerGameOver.audio.isPlaying)
				{
					jinglePlayerGameOver.audio.Stop();
				}
				jingleAlreadyPlayed = false;
				gameOver = false;
				numOfLives = lives; // Reset lives
				lightCount = 100;
				Player_Boost.onThrust = false;
				Player_Boost.onBreak = false;
				
				switch(GameOverSelect)
				{
				case 1:
					Application.LoadLevel(Application.loadedLevel);
					break;
				case 2:
					Application.LoadLevel("Level_Select");
					break;
				case 3:
					Application.LoadLevel("Intro");
					break;
				case 4:
					Application.Quit();
					break;
										
				}
				
			}
			
		}
		

		// Upon no lives it is Game Over
		if(numOfLives < 1 && infiniteLives == false)
		{
			gameOver = true;
			lightCount = 100;
			Player_Boost.onThrust = false;
			Player_Boost.onBreak = false;
		}
		
		// Limit number of lives to 5
		if(numOfLives > 5 && infiniteLives == false)
		{
			numOfLives = 5;
		}
		
		// Press enter to restart the level if you won
		if(winLevel)
		{
			lightCount = 100;
			Player_Boost.onThrust = false;
			Player_Boost.onBreak = false;
			// Play winning music
			if(jingleAlreadyPlayed == false)
			{
				audio.Stop();
				jinglePlayerWinLevel.audio.Play();
				jingleAlreadyPlayed = true;
			}
			
			// Press enter to go to next level
			if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7"))
			{
				if(jinglePlayerWinLevel.audio.isPlaying)
				{
					jinglePlayerWinLevel.audio.Stop();
				}
				jingleAlreadyPlayed = false;
				
				Move_360.thrustSpeed = 700f;
				winLevel = false;
				numOfLives = lives; // Reset lives
				lightCount = 100;
				
				// Load next level if there is a next level
				if(Application.loadedLevel < Application.levelCount - 1)
				{
					infiniteLives = false;
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
			lightCount -= (playerBoostCost * Time.deltaTime);
		
		if(Player_Boost.onBreak)
			lightCount -= (playerBoostCost*1.5f*Time.deltaTime);
		if(lightCount > 100)
			lightCount = 100;
		
		if(lightCount < 0)
			lightCount = 0;
		
		if(lightCount == 0)
		{
			Move_360.thrustSpeed = 700f;
			Player_Boost.onThrust = false;
			Player_Boost.onBreak = false;
		}
		//Debug.Log ((int)lightCount);
		
		if(Input.GetKeyDown (KeyCode.LeftAlt) || Input.GetKeyDown (KeyCode.RightAlt))
		{
			if(toggleGUI)
				toggleGUI = false;
			else
				toggleGUI = true;
		}
		
		//==================================================================================
		// POWER-UP MANAGEMENT
		//==================================================================================
		if(Power_Up_Management.pu_Juice_Invoke)
		{
			Power_Up_Management.pu_Juice_Invoke = false;
			Invoke ("pu_Juice_Invoke", 10.0f);
		}
		if(Power_Up_Management.pu_EcoBoost_Invoke)
		{
			if(lightCount < 2)
			{
				Power_Up_Management.pu_EcoBoost_Invoke = false;
				Invoke ("pu_EcoBoost_Invoke", 0.0f);				
			}
		}
		if(Power_Up_Management.pu_Aura_Invoke)
		{
			Power_Up_Management.pu_Aura_Invoke = false;
			Invoke ("pu_Aura_Invoke",15.0f);
		}
		if(Power_Up_Management.pu_SpotLight_Effect == true)
		{
			Power_Up_Management.pu_SpotLight_Effect = false;
			pu_SpotLight_Create();
			Invoke ("pu_SpotLight_Invoke", 3.0f);
		}
		if(Power_Up_Management.pu_Nitro_Invoke == true)
		{
			Power_Up_Management.pu_Nitro_Invoke	= false;
			Invoke ("pu_Nitro_Invoke", 15.0f);
		}
	}
	void pu_Juice_Invoke(){Manage_Game.lightRegen = Power_Up_Management.tempPuJuice;}
	void pu_EcoBoost_Invoke(){ Manage_Game.playerBoostCost = Power_Up_Management.tempEcoBoost;}
	void pu_Aura_Invoke(){Power_Up_Management.pu_Aura_Effect = false;}
	void pu_SpotLight_Create()
	{
		Power_Up_Management.pu_SpotLight_Invoke = true;
		foreach(GameObject lB in GameObject.FindGameObjectsWithTag("Light_Beacon"))
		{
			Instantiate (TB,lB.transform.position,lB.transform.rotation);
		}
		
	}
	void pu_SpotLight_Invoke() { Power_Up_Management.pu_SpotLight_Invoke = false;}
	void pu_Nitro_Invoke() {Manage_Game.playerBoostCost = Power_Up_Management.tempPuNitro;}
	////////////////////////
	// OnGUI Event
	////////////////////////
	
	

	// Used to draw the GUI
	void OnGUI()
	{
		float arrowPixel = 5000;
		// Draw game over display
		if(gameOver)
		{
			switch(GameOverSelect)
			{
			case 1:
				arrowPixel = 65;
				break;
			case 2:
				arrowPixel = 10;
				break;
			case 3:
				arrowPixel = -45;
				break;
			case 4:
				arrowPixel = -108;
				break;
			default:
				arrowPixel = -175;
				break;
			}
			Rect GameOverArrow = new Rect((Screen.width/2.0f) + 120,
										 (Screen.height/2.0f) - arrowPixel, 
				                         imgGameOverArrow.width, 
				                         imgGameOverArrow.height);
			
			Rect splashCanvas = new Rect((Screen.width/2.0f) - (imgGameOver.width/2.0f),
										 (Screen.height/2.0f) - (imgGameOver.height/2.0f), 
				                         imgGameOver.width, 
				                         imgGameOver.height);
			GUI.Label(splashCanvas, imgGameOver);
			GUI.Label(GameOverArrow, imgGameOverArrow);
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
			

			float lVal = 105f/100f;
			GUI.BeginGroup (new Rect(50, Screen.height-130, 250, 110));
				Color temp = GUI.color;
				if(Pause_Menu.isPaused)
					temp.a = 0.1f;
				GUI.color = temp;
			
				
			
				if(Manage_Game.colorState == (int) Manage_Game.Colors.red)
					GUI.color = col_red;
				else if(Manage_Game.colorState == (int) Manage_Game.Colors.green)
					GUI.color = col_green;
				else if(Manage_Game.colorState == (int) Manage_Game.Colors.blue)
					GUI.color = draw_blue;
				else
					GUI.color = temp;
				if(toggleGUI)
				{
					GUI.DrawTexture(new Rect(44f,36f,(float)lightCount*(lVal)*1.5f,16f*1.5f),lightMeter,ScaleMode.StretchToFill);
					GUI.color = temp;
					GUI.DrawTexture (new Rect(0f,0f, 148f*1.5f, 64f*1.5f),lightBar, ScaleMode.ScaleToFit);
				
				}
			
			GUI.EndGroup();
		
			if(infiniteLives == false)
			{
				GUI.BeginGroup (new Rect(Screen.width-350 , Screen.height-115, 310, 100));
				for(int i = 0; i < numOfLives; i++)
				{
					temp = GUI.color;
					if(Pause_Menu.isPaused)
						temp.a = 0.1f;
					GUI.color = temp;
					
					if(toggleGUI)
						GUI.DrawTexture (new Rect( (225-i*75),0,100,100),livesImage);
				}
				GUI.EndGroup ();
			}
			
			Color loopTemp = GUI.color;
			if(viewCurrentLevelImage)
			{
				GUI.BeginGroup (new Rect((Screen.width/2)-(currentLevel.width/2), Screen.height*0.2f,
					currentLevel.width, currentLevel.height));
				
					temp = GUI.color;
					if(!viewCurrentFadeTime)
						viewCurrentLevelImageAlpha-=0.005f;
				
					temp.a = viewCurrentLevelImageAlpha;
				
					if(Pause_Menu.isPaused)
						temp.a = 0.1f;
					GUI.color = temp;
					GUI.DrawTexture (new Rect(0,0, currentLevel.width, currentLevel.height),currentLevel, ScaleMode.ScaleToFit);
				
				GUI.EndGroup();
			}
			
			GUI.color = loopTemp;
			//Rect lightCanvas = new Rect(450, 400, lightBar.width, lightBar.height);
			//GUI.Label(lightCanvas, lightBar);
		}
		
		//Countdown GUI
		if(WillUseCountDown)
		{
			switch(NumberCountDownIsOn)
			{
				case 0:
					canMove = true;
					CountDownCurrent = CountDownGo;
					break;
				case 1:
					CountDownCurrent = CountDown1;
					break;
				case 2:
					CountDownCurrent = CountDown2;
					break;
				case 3:
					CountDownCurrent = CountDown3;
					break;
				default:
					break;
			}
			
			Color loopTemp = GUI.color;
			if(NumberCountDownIsOn < 4 && NumberCountDownIsOn > -1)
			{
				GUI.BeginGroup (new Rect(Screen.width/2 - CountDownCurrent.width/2, Screen.height/2 - CountDownCurrent.height/1.5f, CountDownCurrent.width, CountDownCurrent.height));
					if(NumberCountDownIsOn == 0)
					{
						Color temp = GUI.color;
						CountDownAlphaGo -= 0.015f;
						temp.a = CountDownAlphaGo;
						GUI.color = temp;
					}
					GUI.DrawTexture(new Rect(0,0,CountDownCurrent.width,CountDownCurrent.height),CountDownCurrent,ScaleMode.StretchToFill);
				GUI.EndGroup ();
			}
			GUI.color = loopTemp;
		}
		
		applyFloatingText (Apply_Checkpoint.doCheckpointAnimation,checkpoint,Apply_Checkpoint.checkpointYIncrementer);
		
		/*
		if(Apply_Checkpoint.doCheckpointAnimation)
		{
			Rect chk = new Rect(Screen.width/2 - checkpoint.width/2 + Screen.width*0.02f, Screen.height/2 - checkpoint.height/2 - Screen.height*0.05f - Apply_Checkpoint.checkpointYIncrementer, checkpoint.width,checkpoint.height);	
			GUI.Label (chk,checkpoint);
		}*/
	}
	
	void FadeLevelImageOut()
	{
		Invoke ("noSeriouslyLetsGetRidOfIt", 3.0f);
		viewCurrentFadeTime = false;
	}
	
	void noSeriouslyLetsGetRidOfIt() { viewCurrentLevelImage = false; }
	
	/*Functions are for countdown------------------------------------------------------------*/
	void CountDown() { NumberCountDownIsOn--; }
	
	//Apply a floating text over the object
	void applyFloatingText(bool doIt, Texture2D texture, float yIncrementer)
	{
		if(doIt)
		{
			Rect chk = new Rect(Screen.width/2 - texture.width/2 + Screen.width*0.02f, Screen.height/2 - texture.height/2 - Screen.height*0.03f - yIncrementer, texture.width,texture.height);	
			GUI.Label (chk,texture);				
		}
	}
}
