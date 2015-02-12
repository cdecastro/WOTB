using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject startingWizard;
	public static GameObject selectedWizard;
	public GameObject parties;
	Vector3 origin = new Vector3(0f,0f,0f);
	Vector3 wizardStartingPosition = new Vector3(39.5f,0f,-39.6f);
	string hipsterTag = "Hipster";
	string itemTag = "Can";

	void Start() {
		selectedWizard = startingWizard;
		Debug.Log(selectedWizard);
		SetWizardPosition(origin);
		ClearPark();
	}

	//wizard setup
	void SetWizardPosition(Vector3 wizardPosition) {
		selectedWizard.transform.position = wizardPosition;
	}

	//park setup
	public void ClearPark() {
		//find & disable all parties
		parties.SetActive(false);
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

	public void StartPark() {
		SetWizardPosition(wizardStartingPosition);
		parties.SetActive(true);
		Camera.main.GetComponent<CameraFollow>().TiltDown(true);
	}

	//pause park
	public void PausePark(bool pause) {
		if (pause) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}

	//inventory management
}
