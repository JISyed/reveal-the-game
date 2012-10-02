using UnityEngine;
using System.Collections;

public class Change_Beacon_State : MonoBehaviour {
	
	public static bool activated;
	public Material matDim;
	public Material matBright;
	
	// Use this for initialization
	void Start () {
		activated = false;
		renderer.material = matDim;
		light.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		Destroy(other.gameObject); // Suppose to destroy lightwaves
		
		// Change to state of the beacon
		if(activated)
		{
			activated = false;
			renderer.material = matDim;
			light.enabled = false;
		}
		else
		{
			activated = true;
			renderer.material = matBright;
			light.enabled = true;
		}
	}
	
}
