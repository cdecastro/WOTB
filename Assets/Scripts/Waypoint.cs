using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

	public string playerTag = "Player";
	public string hipsterTag = "Hipster";
	public string wizardTag = "Wizard";

	void Update () {
		if (CameraFollow.selected.tag != playerTag){
			gameObject.SetActive(false);
		}
	}

	// disable on player collision
	void OnTriggerStay(Collider other) {
		if(other.CompareTag(playerTag) || other.CompareTag(hipsterTag) || other.CompareTag(wizardTag)){
			gameObject.SetActive(false);
		}
	}

}
