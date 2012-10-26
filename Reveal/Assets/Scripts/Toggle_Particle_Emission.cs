using UnityEngine;
using System.Collections;

// Only for use with the Prism boost particles!!

// Credit to profanicus
// http://forum.unity3d.com/threads/118117-Starting-and-Stopping-Emitters-in-the-new-Shuriken-Particle-System?p=791969&viewfull=1#post791969

public class Toggle_Particle_Emission : MonoBehaviour {
	
	public static ParticleSystem myParticles;
	
	// Use this for initialization
	void Start () 
	{
		myParticles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire2"))
		{
			myParticles.Play();
		}
		
		if(Input.GetButtonUp("Fire2"))
		{
			myParticles.Stop();
		}
		
		if(Player_Boost.onThrust == false)
		{
			myParticles.Stop();
		}
	}
}
