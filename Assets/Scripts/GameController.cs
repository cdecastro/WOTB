using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	Vector3 cameraStartingPosition;
	GameObject startingWizard;
	Vector3 wizardStartingPosition = new Vector3(39.5f,0f,-39.6f);
	string partyTag = "Party";
	string hipsterTag = "Hipster";
	string itemTag = "Can";

	void Start() {
		SetCameraPosition();
		ClearPark();
	}

	//camera setup
	void SetCameraPosition() {
		//set camerapostion
	}

	//inventory management

	//wizard setup
	void SetWizardPosition() {

	}


	//park setup
	void ClearPark() {
		//find & disable all parties
		GameObject[] parties;
		parties = GameObject.FindGameObjectsWithTag(partyTag);
		foreach (GameObject party in parties) {
			party.SetActive(false);
		}
		//find & destroy all hipsters
		GameObject[] hipsters;
		hipsters = GameObject.FindGameObjectsWithTag(hipsterTag);
		foreach (GameObject hipster in hipsters) {
			Destroy(hipster);
		}
		//find & destroy all items
		GameObject[] items;
		items = GameObject.FindGameObjectsWithTag(itemTag);
		foreach (GameObject item in items) {
			Destroy(item);
		}
	}

	void StartPark() {
		SetWizardPosition();
	}

	//pause park
	void PausePark() {

	}
}
