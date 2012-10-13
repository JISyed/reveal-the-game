using UnityEngine;
using System.Collections;

public class Change_Level_OnEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 7"))
			Application.LoadLevel("Level_Tutorial");
	}
}
