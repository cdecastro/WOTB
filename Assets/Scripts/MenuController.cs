using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	Vector3 startingMenuPosition;
	Vector3 startingCameraPosition;


	// Use this for initialization
	void Start () {
		startingMenuPosition = transform.position;
		startingCameraPosition = Camera.main.transform.position;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = startingMenuPosition + (Camera.main.transform.position - startingCameraPosition);
	}
}
