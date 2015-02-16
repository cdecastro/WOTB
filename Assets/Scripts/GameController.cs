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
	string actorUITag = "ActorUI";
	string menuControllerTag = "MenuController";
	bool parkActive = false;
	public GameObject menuButton;
	public GameObject waypoint;
	public bool pausePark;
	float minFOV;

	void Start() {
		//turn off menu button
		menuButton.SetActive(false);
		//the selected wizard is the starting wizard
		selectedWizard = startingWizard;
		//place wizard to origin position
		SetWizardPosition(origin);
		//clear the park
		ClearPark();
		//setup the camera fov check, pausing park will only happen once the camera has reset
		minFOV = Camera.main.GetComponent<CameraFollow>().minFov;
	}

	void Update() {
		// pause park once the camera has finished zooming in
		float cameraFOV = Camera.main.fieldOfView;
		if (pausePark && cameraFOV == minFOV) {
			Time.timeScale = 0f;
		} else {
			Time.timeScale = 1f;
		}
	}

	//start game from title screen
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
		//enable menu button
		menuButton.SetActive(true);
		// if the park hasn't been started, startup park
		if (parkActive == false){
			SetWizardPosition(wizardStartingPosition);
			parties.SetActive(true);
			Camera.main.GetComponent<CameraFollow>().TiltDown();
			parkActive = true;
		} else { //if the park has already begun just pause the park
			pausePark = false;
			Camera.main.GetComponent<CameraFollow>().TiltDown();
			//reset selected to last wizard, avoid following hipster with no UI
			CameraFollow.selected = CameraFollow.lastWizardSelected;
		}
	}

	public void MenuButton() {
		//pause park
		pausePark = true;
		//tilt camera
		Camera.main.GetComponent<CameraFollow>().TiltDown();
		//turn on menu button
		menuButton.SetActive(false);
		//kill waypoint so camera resets
		waypoint.SetActive(false);
		//find all actor UIs and turn them off
		GameObject[] actorUIs;
		actorUIs = GameObject.FindGameObjectsWithTag(actorUITag);
		foreach (GameObject actorUI in actorUIs) {
			actorUI.SetActive(false);
		}
	}

	//inventory management
}
