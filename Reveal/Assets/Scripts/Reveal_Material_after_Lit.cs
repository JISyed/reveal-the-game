using UnityEngine;
using System.Collections;

public class Reveal_Material_after_Lit : MonoBehaviour {
	
	private bool revealed = false;
	private bool alreadyRevealed = false;
	
	private float revealSpeed = 2.0f;
	private float maxBrightRatio = 0.2f;
	
	// Use this for initialization
	void Start () 
	{
		// Concealed at first
		renderer.material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(revealed && !alreadyRevealed)
		{
			renderer.material.color += Color.grey /revealSpeed * Time.deltaTime;
		}
		
		if(renderer.material.color.r > maxBrightRatio)
		{
			alreadyRevealed = true;
		}
		
	}
	
	// Collision
	void OnTriggerEnter(Collider other)
	{
		// Turret_Bullet is the only unlit object that can collide with revealables
		// because of Physics settings. So exclude it.
		if(other.gameObject.name != "Turret_Bullet(Clone)")
		{
			revealed = true;
		}
	}
}
