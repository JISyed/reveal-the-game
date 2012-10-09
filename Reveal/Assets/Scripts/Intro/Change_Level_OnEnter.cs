using UnityEngine;
using System.Collections;

public class Change_Level_OnEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown (KeyCode.Return))
			Application.LoadLevel("Jibs_Test");
	}
}
