using UnityEngine;
using System.Collections;

public class Play_Sound_On_Enter : MonoBehaviour {
	public static bool CanDo = true;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if(CanDo)
		{
			if(Input.GetKeyDown (KeyCode.Return))
				audio.Play ();	
		}
	}
}
