using UnityEngine;
using System.Collections;

public class Camera_Follow_Player : MonoBehaviour {
	public GameObject player;
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition = player.transform.position;
		newPosition.y = player.transform.position.y + 50;
		transform.position = newPosition;
	}
}
