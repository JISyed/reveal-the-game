using UnityEngine;
using System.Collections;

public class GUIa : MonoBehaviour {

	public Texture2D introGUI;
	private bool didItAlready = false;
	private float alpha = 1.0f;
	
	void Start()
	{
		alpha = 1.0f;
		didItAlready = false;	
	}
	void OnGUI()
	{
		
		Rect splashCanvas = new Rect((Screen.width/2.0f) - (introGUI.width/2.0f),
										 (Screen.height/2.0f) - (introGUI.height/2.0f), 
				                         introGUI.width, 
				                         introGUI.height);
		Color temp = GUI.color;
		if(didItAlready)
			alpha -= 0.005f; //Please change this, stupidest thing ever
		temp.a = alpha;
		GUI.color = temp;
		GUI.Label(splashCanvas, introGUI);
	}
	
	void Update () {
	
		if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7")) && didItAlready != true)
		{
			didItAlready = true;
			Invoke ("goAhead", 3.0f);
		}
		

	}
	
	void goAhead()
	{
		Application.LoadLevel("Level_Tutorial");
	}
}

