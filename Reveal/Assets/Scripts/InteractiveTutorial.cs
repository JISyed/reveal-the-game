using UnityEngine;
using System.Collections;

public class InteractiveTutorial : MonoBehaviour {
	
	
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
	public Texture2D text8;
	public Texture2D text9;
	public Texture2D text10;
	public Texture2D text11;
	public Texture2D text12;
	public Texture2D text13;
	public Texture2D text14;
	public Texture2D text15;
	public Texture2D text16;
	public Texture2D text17;
	public Texture2D text18;
	public Texture2D text19;
	public Texture2D text20;
	public Texture2D text21;
	private Texture2D currentText;
	
	private float alpha;
	private bool[] fadeIn;
	private bool[] fadeOut;
	
	public static int currentOne = 0;
	
	public static bool fourthStringReady = false;
	//bool fourthStringReadySpawnLightOnce = false;
	public GameObject lightBeaconTesting;
	
	public static bool Shooting_Tutorial_Criteria = false;
	public static bool Shooting_Tutorial_GotShot = false;
	public static bool Shooting_Tutorial_GotShotCalled = false;
	public static bool Call_Pass_Fade_Out_Immediate = false;
	
	public static bool Shooting_Tutorial_Beacon = false;
	public static bool Shooting_Tutorial_BeaconCalled = false;
	
	public static bool Prism_Tutorial_Collide = false;
	public static bool Prism_Tutorial_CollideCalled = false;
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
		
		Invoke("fi1", 1.0f);
		Invoke("fo1", 11.0f);
		Invoke("fi2", 12.0f);
		Invoke("fo2", 22.0f);
		Invoke("fi3", 23.0f);
		Invoke("fo3", 33.0f);
		Invoke("fi4", 34.0f);
		Invoke("fo4", 44.0f);
		Invoke("fi5", 45.0f);
		Invoke("fo5", 50.0f);		
		Shooting_Tutorial_Criteria = false;
		Shooting_Tutorial_GotShot= false;
		Shooting_Tutorial_GotShotCalled = false;
		Shooting_Tutorial_Beacon = false;
		Shooting_Tutorial_BeaconCalled = false;
		Prism_Tutorial_Collide = false;
		Prism_Tutorial_CollideCalled = false;
	}
	void Update()
	{
		if((Input.GetButtonDown("Fire1") && !Manage_Game.canMove &&  InteractiveTutorial.Shooting_Tutorial_Criteria))
		{
			if(Shooting_Tutorial_GotShot == false)
				Shooting_Tutorial_GotShot = true;
		}
		if(Shooting_Tutorial_GotShot)
		{
			if(!Shooting_Tutorial_GotShotCalled)
			{
				Invoke("fi6", 0.0f);
				Invoke("fo6", 10.0f);
				Invoke("fi7", 11.0f);
				Invoke("fo7", 21.0f);
				Invoke("fi8", 22.0f);
				Invoke("fo8", 32.0f);
				Invoke("fi9", 33.0f);
				Invoke("fo9", 43.0f);
				Shooting_Tutorial_GotShotCalled = true;
			}
		}
		
		if(Shooting_Tutorial_Beacon)
		{
			if(!Shooting_Tutorial_BeaconCalled)
			{
				Invoke ("fi10", 0.0f);
				Invoke ("fo10", 10.0f);
				Invoke ("fi11", 11.0f);
				Invoke ("fo11", 21.0f);
				Invoke ("fi12", 22.0f);
				Invoke ("goMove", 28.0f);
				Invoke ("fo12", 32.0f);
				Shooting_Tutorial_BeaconCalled = true;
			}
		}
		if(Prism_Tutorial_Collide)
		{
			if(!Prism_Tutorial_CollideCalled)
			{
				Invoke ("stopMoving", 0.0f);
				Invoke ("fi13", 0.0f);
				Invoke ("fo13", 10.0f);
				Invoke ("fi14", 11.0f);
				Invoke ("fo14", 21.0f);
				Invoke ("fi15", 22.0f);
				Invoke ("fo15", 32.0f);
				Invoke ("fi16", 33.0f);
				Invoke ("fo16", 43.0f);
				Invoke ("fi17", 44.0f);
				Invoke ("fo17", 54.0f);
				Invoke ("fi18", 55.0f);
				Invoke ("goMove", 60.0f);
				Invoke ("fo18", 65.0f);
				Invoke ("fi19", 66.0f);
				Invoke ("fo19", 76.0f);
				Invoke ("fi20", 77.0f);
				Invoke ("fo20", 87.0f);
				Invoke ("fi21", 88.0f);
				Invoke ("fo21", 98.0f);
				Prism_Tutorial_CollideCalled = true;
			}
		}
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
			case 7:
				currentText = text8;
				break;
			case 8:
				currentText = text9;
				break;
			case 9:
				currentText = text10;
				break;
			case 10:
				currentText = text11;
				break;
			case 11:
				currentText = text12;
				break;
			case 12:
				currentText = text13;
				break;
			case 13:
				currentText = text14;
				break;
			case 14:
				currentText = text15;
				break;
			case 15:
				currentText = text16;
				break;	
			case 16:
				currentText = text17;
				break;
			case 17:
				currentText = text18;
				break;
			case 18:
				currentText = text19;
				break;
			case 19:
				currentText = text20;
				break;
			case 20:
				currentText = text21;
				break;
			default:
				currentText = text21;
				break;
		}
		
		Rect splashCanvas = new Rect(Screen.width/2-(currentText.width/2),Screen.height-100,512,128);
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
		
		if(currentOne == 5 && !Call_Pass_Fade_Out_Immediate)
		{
			alpha = 0;
			Call_Pass_Fade_Out_Immediate = true;
		}
		temp.a = alpha;
		GUI.color = temp;
		GUI.Label(splashCanvas, currentText);
	}
	
	void goMove()
	{
		Manage_Game.canMove = true;	
	}	
	void stopMoving()
	{
		Manage_Game.canMove = false;
	}
	void fi1(){ currentOne = 0;fadeIn[0] = true;}
	void fo1(){ currentOne = 0;fadeOut[0] = true; fadeIn[0] = false;}
	void fi2(){ currentOne = 1;fadeIn[1] = true; fadeOut[0] = false;}
	void fo2(){ currentOne = 1;fadeOut[1] = true; fadeIn[1] = false;}
	void fi3(){ currentOne = 2;fadeIn[2] = true; fadeOut[1] = false;}
	void fo3(){ currentOne = 2;fadeOut[2] = true; fadeIn[2] = false;}	
	void fi4(){ currentOne = 3;fadeIn[3] = true; fadeOut[2] = false;}
	void fo4(){ currentOne = 3;fadeOut[3] = true; fadeIn[3] = false;}
	void fi5(){ currentOne = 4;fadeIn[4] = true; fadeOut[3] = false;fourthStringReady = true; Shooting_Tutorial_Criteria = true;}
	void fo5(){ if(!Shooting_Tutorial_GotShot){currentOne = 4;fadeOut[4] = true; fadeIn[4] = false;}}
	
	void fi6(){ currentOne = 5;fadeIn[5] = true; fadeOut[4] = false;}
	void fo6(){ currentOne = 5;fadeOut[5] = true; fadeIn[5] = false;}
	void fi7(){ currentOne = 6;fadeIn[6] = true; fadeOut[5] = false;}
	void fo7(){ currentOne = 6;fadeOut[6] = true; fadeIn[6] = false;}
	
	void fi8(){ currentOne = 7;fadeIn[7] = true; fadeOut[6] = false;}
	void fo8(){ currentOne = 7;fadeOut[7] = true; fadeIn[7] = false;}
	void fi9(){ currentOne = 8;fadeIn[8] = true; fadeOut[7] = false;}
	void fo9(){ if(!Shooting_Tutorial_Beacon){currentOne = 8;fadeOut[8] = true; fadeIn[8] = false;}}
	
	void fi10(){ currentOne = 9;fadeIn[9] = true; fadeOut[8] = false;}
	void fo10(){ currentOne = 9;fadeOut[9] = true; fadeIn[9] = false;}
	void fi11(){ currentOne = 10;fadeIn[10] = true; fadeOut[9] = false;}
	void fo11(){ currentOne = 10;fadeOut[10] = true; fadeIn[10] = false;}
	
	void fi12(){ currentOne = 11;fadeIn[11] = true; fadeOut[10] = false;}
	void fo12(){ if(!Prism_Tutorial_Collide){ currentOne = 11;fadeOut[11] = true; fadeIn[11] = false;}}
	
	void fi13(){ currentOne = 12;fadeIn[12] = true; fadeOut[11] = false;}
	void fo13(){ currentOne = 12;fadeOut[12] = true; fadeIn[12] = false;}
	void fi14(){ currentOne = 13;fadeIn[13] = true; fadeOut[12] = false; Manage_Game.colorState = (int) Manage_Game.Colors.white;}
	void fo14(){ currentOne = 13;fadeOut[13] = true; fadeIn[13] = false;}
	void fi15(){ currentOne = 14;fadeIn[14] = true; fadeOut[13] = false;}
	void fo15(){ currentOne = 14;fadeOut[14] = true; fadeIn[14] = false;}
	void fi16(){ currentOne = 15;fadeIn[15] = true; fadeOut[14] = false;}
	void fo16(){ currentOne = 15;fadeOut[15] = true; fadeIn[15] = false;}
	void fi17(){ currentOne = 16;fadeIn[16] = true; fadeOut[15] = false;}
	void fo17(){ currentOne = 16;fadeOut[16] = true; fadeIn[16] = false;}
	void fi18(){ currentOne = 17;fadeIn[17] = true; fadeOut[16] = false;}
	void fo18(){ currentOne = 17;fadeOut[17] = true; fadeIn[17] = false;}
	void fi19(){ currentOne = 18;fadeIn[18] = true; fadeOut[17] = false;}
	void fo19(){ currentOne = 18;fadeOut[18] = true; fadeIn[18] = false;}
	void fi20(){ currentOne = 19;fadeIn[19] = true; fadeOut[18] = false;}
	void fo20(){ currentOne = 19;fadeOut[19] = true; fadeIn[19] = false;}
	void fi21(){ currentOne = 20;fadeIn[20] = true; fadeOut[19] = false;}
	void fo21(){ currentOne = 20;fadeOut[20] = true; fadeIn[20] = false;}
}
