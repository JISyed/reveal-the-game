using UnityEngine;
using System.Collections;

public class Skip_Tutorial : MonoBehaviour {
	
	public Texture2D skip;
	public float skipTextureAlpha = 1.0f;
	private bool fadeInOrOut = false; //false = out, true = in
	private bool stopIt = false;
	// Update is called once per frame
	void Start()
	{
		Invoke ("stopFlashingTheStupidRequest", 10.0f);
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.Backspace) && !Pause_Menu.isPaused)
		{
			Manage_Game.canMove = true;
			Manage_Game.infiniteLives = false;
			Manage_Game.numOfLives = 3;
			Application.LoadLevel("Level_New_One");
		}
	}
	void OnGUI()
	{
		if(!stopIt)
		{
			Color loopTemp = GUI.color;
			GUI.BeginGroup (new Rect(25,25,skip.width,skip.height));
			
				Color temp = GUI.color;
				if(fadeInOrOut)
					skipTextureAlpha+=0.003f;
				else
					skipTextureAlpha-=0.003f;
			
				if(skipTextureAlpha >= 0.95f)
					fadeInOrOut = false;
			
				if(skipTextureAlpha <= 0.05f)
					fadeInOrOut = true;
				temp.a = skipTextureAlpha;
			
				GUI.color = temp;
				GUI.DrawTexture (new Rect(0,0, skip.width,skip.height),skip, ScaleMode.StretchToFill);
			
			GUI.EndGroup();
			GUI.color = loopTemp;
		}
	}
	
	void stopFlashingTheStupidRequest()
	{
		stopIt = true;
	}
}
