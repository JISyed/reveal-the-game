using UnityEngine;
using System.Collections;

public class Play_Sound_On_Arrows : MonoBehaviour {
	
	public static bool CanDo = true;
	// Update is called once per frame
	void Update () {
		if(CanDo)
		{
			if(Input.GetKeyDown (KeyCode.UpArrow)
				|| Input.GetKeyDown (KeyCode.DownArrow)
				|| Input.GetKeyDown (KeyCode.LeftArrow)
				|| Input.GetKeyDown (KeyCode.RightArrow))
				audio.Play();
		}
	}
}
