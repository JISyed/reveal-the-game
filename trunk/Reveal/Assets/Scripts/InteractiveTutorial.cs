using UnityEngine;
using System.Collections;

public class InteractiveTutorial : MonoBehaviour {
	
	public Texture2D text1;
	public Texture2D text2;
	public Texture2D text3;
	public Texture2D text4;
	public Texture2D text5;
	public Texture2D text6;
	public Texture2D text7;
	private Texture2D currentText;
	
	private float alpha;
	private bool[] fadeIn;
	private bool[] fadeOut;
	
	int currentOne = 0;
	
	// Use this for initialization
	void Start () {
		//alpha = new float[7];
		fadeIn = new bool[7];
		fadeOut = new bool[7];
		Manage_Game.canMove = false;
		
		//for(int a = 0; a < 7; a++)
			//alpha[a] = 0.0f;
	
		for(int b = 0; b < 7; b++)
			fadeIn[b] = false;
		
		for(int c = 0; c < 7; c++)
			fadeOut[c] = false;
		
		Invoke("fi1", 1.0f);
		Invoke("fo1", 11.0f);
		Invoke("fi2", 12.0f);
		Invoke("fo2", 22.0f);
		Invoke("fi3", 23.0f);
		Invoke("fo3", 33.0f);
		Invoke("fi4", 34.0f);
		Invoke("goMove", 40.0f);
		Invoke("fo4", 44.0f);
		Invoke("fi5", 45.0f);
		Invoke("fo5", 55.0f);
		Invoke("fi6", 56.0f);
		Invoke("fo6", 66.0f);
		Invoke("fi7", 67.0f);
		Invoke("fo7", 77.0f);
	}
	
	void OnGUI()
	{
		switch(currentOne)
		{
			case 0:
				currentText = text1;
				break;
			case 1:
				currentText = text2;
				break;
			case 2:
				currentText = text3;
				break;
			case 3:
				currentText = text4;
				break;
			case 4:
				currentText = text5;
				break;
			case 5:
				currentText = text6;
				break;
			case 6:
				currentText = text7;
				break;
			default:
				currentText = text6;
				break;
		}
		Rect splashCanvas = new Rect(Screen.width-450,Screen.height-130,512,128);
		Color temp = GUI.color;
		if(fadeIn[currentOne])
		{
			alpha += 0.020f; //Please change this, stupidest thing ever
			if(alpha > 1)
				alpha = 1;	
		}
	
		if(fadeOut[currentOne])
		{
			alpha -= 0.020f; //Please change this, stupidest thing ever
			if(alpha < 0)
				alpha = 0;				
		}
		temp.a = alpha;
		GUI.color = temp;
		GUI.Label(splashCanvas, currentText);
	}
	
	void goMove()
	{
		Manage_Game.canMove = true;	
	}
	void fi1(){ currentOne = 0;fadeIn[0] = true;}
	void fo1(){ currentOne = 0;fadeOut[0] = true; fadeIn[0] = false;}
	void fi2(){ currentOne = 1;fadeIn[1] = true; fadeOut[0] = false;}
	void fo2(){ currentOne = 1;fadeOut[1] = true; fadeIn[1] = false;}
	void fi3(){ currentOne = 2;fadeIn[2] = true; fadeOut[1] = false;}
	void fo3(){ currentOne = 2;fadeOut[2] = true; fadeIn[2] = false;}
	void fi4(){ currentOne = 3;fadeIn[3] = true; fadeOut[2] = false;}
	void fo4(){ currentOne = 3;fadeOut[3] = true; fadeIn[3] = false;}
	void fi5(){ currentOne = 4;fadeIn[4] = true; fadeOut[3] = false;}
	void fo5(){ currentOne = 4;fadeOut[4] = true; fadeIn[4] = false;}
	void fi6(){ currentOne = 5;fadeIn[5] = true; fadeOut[4] = false;}
	void fo6(){ currentOne = 5;fadeOut[5] = true; fadeIn[5] = false;}
	void fi7(){ currentOne = 6;fadeIn[6] = true; fadeOut[5] = false;}
	void fo7(){ currentOne = 6;fadeOut[6] = true; fadeIn[6] = false;}	
}
