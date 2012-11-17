using UnityEngine;
using System.Collections;

public class Interactive_Credits : MonoBehaviour {
	
	
	/*
	string TUTORIAL1 = "Welcome to Reveal! In this tutorial we will be covering everything you need to know about this game.";
	string TUTORIAL2 = "The goal of the game is to navigate through each level using your prism as your player.";
	string TUTORIAL3 = "Because you are navigating in the dark, you will use your prism to shoot helixes that will light up the path.";
	string TUTORIAL4 = "This is important because if you hit the walls or collide with other objects, you will die.";
	string TUTORIAL5 = "Let's try it out. Press space now to shoot a helix.";
	string TUTORIAL6 = "Good, as you shoot a helix you will notice that your light bar on the bottom left diminishes with each shot.";
	string TUTORIAL7 = "Depending on the difficulty, you will need to be careful with how much you use it throughout the game.";
	string TUTORIAL8 = "Lets continue.";
	string TUTORIAL9 = "The beacon in front of you will light up for 3 seconds when you shoot a helix at it. Go ahead and try it.";
	string TUTORIAL10 = "Good! This is a very useful tool needed many times throughout the entire game. Lets continue.";
	string TUTORIAL11 = "In front of you is a green prism. When you run over it you will change colors.";
	string TUTORIAL12 = "This will allow you to shoot color coded walls to get through it. Go ahead and try it now.";
	string TUTORIAL13 = "Excellent! There are many colors throughout the entire game.";
	string TUTORIAL14 = "Oh, and i'm sure you know that you can pause the game by hitting ESC, as well as hitting ALT to hide your GUI.";
	string TUTORIAL15 = "The last part in the game is the turrets. Turrets will fire bullets at you that would kill you instantly.";
	string TUTORIAL16 = "Fire at them to defelct the bullets. The bullets may be used to break certain cracked walls.";
	string TUTORIAL17 = "Oh, I almost forgot about one more important detail. Your prism doesn't stop moving.";
	string TUTORIAL18 = "It makes the gameplay so much more fun, don't you agree? Try to complete this tutorial by getting to the end.";
	string TUTORIAL19 = "You can use the W,A,D or arrow keys to move your prism, and SHIFT to boost (it does cost light of course).";
	string TUTORIAL20 = "Once you reach the TIC-TAC shaped object, you win the level! You will begin your journey after this level.";
	string TUTORIAL21 = "Good luck and have fun.";
	string TUTORIALSTR;*/
	
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
	
	public static int currentOne = 0;
	

	// Use this for initialization
	void Start () {
		//alpha = new float[7];
		fadeIn = new bool[21];
		fadeOut = new bool[21];
		Manage_Game.canMove = false;
		
		//for(int a = 0; a < 7; a++)
			//alpha[a] = 0.0f;
	
		for(int b = 0; b < 7; b++)
			fadeIn[b] = false;
		
		for(int c = 0; c < 7; c++)
			fadeOut[c] = false;
		
		Invoke("fi1", 0.0f);
		Invoke("fo1", 4.0f);
		Invoke("fi2", 5.0f);
		Invoke("fo2", 9.0f);
		Invoke("fi3", 10.0f);
		Invoke("fo3", 14.0f);
		Invoke("fi4", 15.0f);
		Invoke("fo4", 19.0f);
		Invoke("fi5", 20.0f);
		Invoke("fo5", 24.0f);
		Invoke("fi6", 25.0f);
		Invoke("fo6", 29.0f);
		Invoke("fi7", 30.0f);
		Invoke("fo7", 34.0f);
		Invoke ("gtfo", 35.0f);
	}
	void Update()
	{
		if(Input.GetKeyDown (KeyCode.Escape))
			Application.LoadLevel ("Intro");
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
				currentText = text1;
				break;
		}
		
		Rect splashCanvas = new Rect(Screen.width/2-currentText.width/2, Screen.height/2-currentText.height/2, currentText.width,currentText.height);
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
	
	void gtfo()
	{
		Application.LoadLevel ("Intro");	
	}
}
