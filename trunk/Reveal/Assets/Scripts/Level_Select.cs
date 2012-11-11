using UnityEngine;
using System.Collections;

public class Level_Select : MonoBehaviour {
	private Texture2D LevelSelectCurrent;
	public Texture2D LevelSelect1;
	public Texture2D LevelSelect2;
	public Texture2D LevelSelect3;
	public Texture2D LevelSelect4;
	public Texture2D LevelSelect5;
	public Texture2D LevelSelect6;
	public Texture2D LevelSelect7;
	public Texture2D LevelSelectTutorial;
	public Texture2D LevelSelectBlank;
	public Texture2D blackScreen;
	private int currentSelect = 0;
	private float alpha = 0.0f;
	private bool isSelectionFadeOut = false;
	private bool stopSelecting = false;
	// Use this for initialization
	void Start () {
		isSelectionFadeOut = false;
		stopSelecting = false;
	}
	
	
	void OnGUI()
	{
		switch(currentSelect)	
		{
		case 0:
			LevelSelectCurrent = LevelSelectTutorial;
			break;
		case 1:
			LevelSelectCurrent = LevelSelect1;
			break;
		case 2:
			LevelSelectCurrent = LevelSelect2;
			break;
		case 3:
			LevelSelectCurrent = LevelSelect3;
			break;
		case 4:
			LevelSelectCurrent = LevelSelect4;
			break;
		case 5:
			LevelSelectCurrent = LevelSelect5;
			break;
		case 6:
			LevelSelectCurrent = LevelSelect6;
			break;
		case 7:
			LevelSelectCurrent = LevelSelect7;
			break;
		default:
			LevelSelectCurrent = LevelSelectBlank;
			break;

		}
		
		Rect splashCanvas = new Rect((Screen.width/2.0f) - (LevelSelectCurrent.width/2.0f),
											 (Screen.height/2.0f) - (LevelSelectCurrent.height/2.0f), 
					                         LevelSelectCurrent.width, 
					                         LevelSelectCurrent.height);
		Color temp = GUI.color;



		if(isSelectionFadeOut)
		{
			alpha -= 0.015f; //Please change this, stupidest thing ever
			if(alpha < 0)
				alpha = 0;
		}
		else
		{
			alpha += 0.015f; //Please change this, stupidest thing ever
			if(alpha > 1)
				alpha = 1;			
		}

		
		temp.a = alpha;
		GUI.color = temp;
		GUI.Label(splashCanvas, LevelSelectCurrent);
	}
	// Update is called once per frame
	void Update () {
		
		if(!stopSelecting)
		{
			if(Input.GetKeyDown(KeyCode.DownArrow))
			{
				switch(currentSelect)
				{
					case 0:
						currentSelect = 1;
						break;
					case 4:
						currentSelect = 0;
						break;
					case 7:
						currentSelect = 0;
						break;
					default:
						currentSelect++;
						break;			
				}
			}
			
			if(Input.GetKeyDown(KeyCode.UpArrow))
			{
				switch(currentSelect)
				{
					case 0:
						currentSelect = 7;
						break;
					case 5:
						currentSelect = 0;
						break;
					default:
						currentSelect--;
						break;
				}
			}
			
			if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.LeftArrow))
			{
				switch(currentSelect)
				{
					case 0:
						currentSelect = 0;
						break;
					case 1:
						currentSelect = 5;
						break;
					case 2:
						currentSelect = 6;
						break;
					case 3:
						currentSelect = 7;
						break;
					case 4:
						currentSelect = 4;
						break;
					case 5:
						currentSelect = 1;
						break;
					case 6:
						currentSelect = 2;
						break;
					case 7:
						currentSelect = 3;
						break;
					default:
						currentSelect = 0;
						break;
				}
			}
			
			if(Input.GetKeyDown (KeyCode.Return))
			{
				isSelectionFadeOut = true;
				stopSelecting = true;
				Invoke ("LaunchLevel", 1.5f);
			}
		}
	}
	
	void LaunchLevel()
	{
		switch(currentSelect)
		{
			case 1:
				
				Application.LoadLevel("Level_New_One");
				break;
			case 2:
				Application.LoadLevel("Level_New_Two");
				break;
			case 3:
				Application.LoadLevel("Level_New_Three");
				break;
			case 4:
				Application.LoadLevel("Level_Two");
				break;
			case 5:
				Application.LoadLevel("Level_Three");
				break;
			case 6:
				Application.LoadLevel("Level_One");
				break;
			case 7:
				Application.LoadLevel("Level_New_Seven");
				break;
			case 0:
				Application.LoadLevel("Level_New_Tutorial");
				break;
		}
	}
}
