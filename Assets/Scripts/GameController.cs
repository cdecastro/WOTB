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
	bool parkActive = false;
	public GameObject menuButton;
	public GameObject waypoint;

	void Start() {
		menuButton.SetActive(false);
		selectedWizard = startingWizard;
		SetWizardPosition(origin);
		ClearPark();
	}

	public void StartGame() {
		Camera.main.GetComponent<CameraFollow>().TitleTiltDown();
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
		//park is no longer active
		parkActive = false;
	}

	public void StartPark() {
		menuButton.SetActive(true);
		if (parkActive == false){
			SetWizardPosition(wizardStartingPosition);
			parties.SetActive(true);
			Camera.main.GetComponent<CameraFollow>().TiltDown();
			parkActive = true;
		} else {
			PausePark(false);
			Camera.main.GetComponent<CameraFollow>().TiltDown();
		}
	}

	public void MenuButton() {
		PausePark(true);
		Camera.main.GetComponent<CameraFollow>().TiltDown();
		menuButton.SetActive(false);
		waypoint.SetActive(false);
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
