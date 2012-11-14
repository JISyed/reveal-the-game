using UnityEngine;
using System.Collections;

public class GUIa : MonoBehaviour {

	public Texture2D introGUI;
	private bool didItAlready = false;
	private float alpha = 1.0f;
	
	private bool isSelection = false;
	private bool isSelectionFadeOut = false;
	private Texture2D selectionScreen;
	public Texture2D selectionScreen1;
	public Texture2D selectionScreen2;
	public Texture2D selectionScreen3;
	public Texture2D blackScreen;
	public static int selectionNumber = 1;
	
	
	void Start()
	{
		alpha = 1.0f;
		didItAlready = false;
		isSelection = false;
		isSelectionFadeOut = false;
		selectionNumber = 1;
	}
	void OnGUI()
	{

		if(!isSelection)
		{
			Rect splashCanvas = new Rect((Screen.width/2.0f) - (introGUI.width/2.0f),
											 (Screen.height/2.0f) - (introGUI.height/2.0f), 
					                         introGUI.width, 
					                         introGUI.height);
			Color temp = GUI.color;
			if(didItAlready)
			{
				alpha -= 0.015f; //Please change this, stupidest thing ever
				if(alpha < 0)
					alpha = 0;
			}
			temp.a = alpha;
			GUI.color = temp;
			GUI.Label(splashCanvas, introGUI);
			Play_Sound_On_Arrows.CanDo = false;
		}
		else
		{
			Play_Sound_On_Arrows.CanDo = true;
			switch(selectionNumber)
			{
				case 1:
					selectionScreen = selectionScreen1;
					break;
				case 2:
					selectionScreen = selectionScreen2;
					break;
				case 3:
					selectionScreen = selectionScreen3;
					break;
				default:
					selectionScreen = selectionScreen1;
					break;
			}
			//Rect blackCanvas = new Rect(0,0, 2000, 2000);
			//GUI.Label(blackCanvas, blackScreen);
			Rect splashCanvas = new Rect((Screen.width/2.0f) - (selectionScreen.width/2.0f),
											 (Screen.height/2.0f) - (selectionScreen.height/2.0f), 
					                         selectionScreen.width, 
					                         selectionScreen.height);
			Color temp = GUI.color;
			if(didItAlready && alpha <= 1 && isSelectionFadeOut != true)
			{
				alpha += 0.015f; //Please change this, stupidest thing ever
				if(alpha > 1)
					alpha = 1;
			}
			else if(didItAlready && alpha <= 1 && isSelectionFadeOut == true)
			{
				alpha -= 0.015f; //Please change this, stupidest thing ever
				if(alpha < 0)
					alpha = 0;
			}
			temp.a = alpha;
			GUI.color = temp;
			GUI.Label(splashCanvas, selectionScreen);
		}
		
	}
	
	void Update () {
	
		if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7")) && didItAlready != true)
		{
			didItAlready = true;
			Invoke ("goAhead", 1.0f);
		}
		
		if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7")) && didItAlready == true && isSelection == true)
		{
			isSelectionFadeOut = true;
			Invoke ("loadDifficulty", 1.0f);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
			selectionNumber++;
		if(Input.GetKeyDown(KeyCode.UpArrow))
			selectionNumber--;
		
		if(selectionNumber < 1)
			selectionNumber = 3;
		if(selectionNumber > 3)
			selectionNumber = 1;
		
		if(Input.GetKeyDown (KeyCode.Escape))
			Application.Quit ();
	}
	
	void goAhead()
	{
		isSelection = true;
	}
	
	void loadDifficulty()
	{
		Manage_Game.difficulty = selectionNumber;
		Application.LoadLevel("Level_Select");
	}
	
	void OnDrawGizmos(){}
}

