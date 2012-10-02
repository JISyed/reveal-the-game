// Credit to CookingWithUnity Tutorials.
using UnityEngine;
using System.Collections;

public class Manage_Game : MonoBehaviour {
	
	////////////////////////
	// Variables
	////////////////////////
	
	// Static means shared across instances of GameManager GameObject
	// CANNOT be adjusted in Unity Editor!!!!
	public static int numOfLives;
	public static bool gameOver = false;
	
	// Public variables editable in Editor
	public int lives = 5;
	
	////////////////////////
	// Start Event
	////////////////////////
	
	// Use this for initialization
	void Start () 
	{
		// 'lives' is set in Editor.
		// 'numOfLives' can be accessed by scripts via "Manage_Game.numOfLives".
		numOfLives = lives;
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
			if(Input.GetKeyDown(KeyCode.Return))
			{
				gameOver = false;
				numOfLives = lives; // Reset lives
				Application.LoadLevel("Jibs_Test");
			}
		}
		
		// Upon no lives it is Game Over
		if(numOfLives <= 0)
		{
			gameOver = true;
		}
	}
	
	////////////////////////
	// OnGUI Event
	////////////////////////
	
	// Used to draw the GUI
	void OnGUI()
	{
		// Draw lives stat
		GUI.Label(new Rect(10,0,240,20),"Lives: " + numOfLives.ToString());
		
		// Draw game over display
		if(gameOver)
		{
			GUI.Label(new Rect(Screen.width/2.0f - 60, 
							   Screen.height/2.0f - 10, 
				               120, 
				               20), 
				                    "GAME OVER. Press Enter.");
		}
	}
	
	////////////////////////
	// OnDrawGizmos Event
	////////////////////////
	
	// Only to have a Gizmo manifested in the Editor. Does not appear in game.
	void OnDrawGizmos() {}
}
