using UnityEngine;
using System.Collections;

public class GUIa : MonoBehaviour {

	public Texture2D introGUI;
	
	void OnGUI()
	{
		
		Rect splashCanvas = new Rect((Screen.width/2.0f) - (introGUI.width/2.0f),
										 (Screen.height/2.0f) - (introGUI.height/2.0f), 
				                         introGUI.width, 
				                         introGUI.height);
		GUI.Label(splashCanvas, introGUI);
	}
}

