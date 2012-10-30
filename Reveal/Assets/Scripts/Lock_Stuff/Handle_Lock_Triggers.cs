using UnityEngine;
using System.Collections;

public class Handle_Lock_Triggers : MonoBehaviour {
	
	public GameObject wallPrefab;
	private GameObject wallReference;
	
	private int colorState;
	public string colorToChangeInto;
	
	public GameObject breakingSoundSource;
	
	// Use this for initialization
	void Start () 
	{
		// Disable renderer
		renderer.enabled = false;
		
		// Make a wall at it's position
		wallReference = Instantiate(wallPrefab, transform.position, transform.rotation) as GameObject;
		
		// Set color state
		if(colorToChangeInto == "Red" || colorToChangeInto == "red")
		{
			colorState = (int) Manage_Game.Colors.red;
		}
		else if(colorToChangeInto == "Green" || colorToChangeInto == "green")
		{
			colorState = (int) Manage_Game.Colors.green;
		}
		else if(colorToChangeInto == "Blue" || colorToChangeInto == "blue")
		{
			colorState = (int) Manage_Game.Colors.blue;
		}
		else
		{
			Debug.Log("Invalid string for \"Handle_Lock_Triggers.colorToChangeInto\"");
			colorState = -1;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		// Destroy light beam
		Destroy(other.gameObject);
		
		if(colorState == Move_Lightwave.currentColor)
		{
			// Play some kind of unlocking sound here
			Instantiate(breakingSoundSource, transform.position, transform.rotation);
			// Destroy wall
			Destroy(wallReference);
			// Destroy trigger
			Destroy(gameObject);
			// Reset color state to white
			Manage_Game.colorState = (int) Manage_Game.Colors.white;
		}
	}
}
