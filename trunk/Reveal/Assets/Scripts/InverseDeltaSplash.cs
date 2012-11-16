using UnityEngine;
using System.Collections;

public class InverseDeltaSplash : MonoBehaviour {
	
	public Texture2D introGUI;
	private bool didItAlready = false;
	private float alpha = 1.0f;
	
	// Use this for initialization
	void Start () 
	{
		alpha = 1.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7")) && didItAlready != true)
		{
			didItAlready = true;
			Application.LoadLevel("Intro");
		}
	}
	
	// Draw GUI
	void OnGUI()
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
	}
}
