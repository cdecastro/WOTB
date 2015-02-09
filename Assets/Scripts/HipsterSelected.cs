using UnityEngine;
using System.Collections;

public class HipsterSelected : MonoBehaviour {
	
	public GameObject hipsterUI;
	public GameObject hipsterInfo;
	private float uiTimer;
	public float uiDuration = 5f;
	
	void Start () {
		hipsterUI.SetActive(false);
		hipsterInfo.SetActive(false);
		uiTimer = 0f;		
	}

	void Update() {
		if (uiTimer > 0f){
			uiTimer -= Time.deltaTime;
		} else {
			hipsterUI.SetActive(false);
//			hipsterInfo.SetActive(false);
		}

		if (hipsterInfo.activeSelf == true && CameraFollow.selected != gameObject) {
			hipsterInfo.SetActive(false);
		}
	}
		
	public void TapHipster () {
		uiTimer = uiDuration;
		hipsterUI.SetActive(true);
	}
	
	public void SelectHipster () {
		CameraFollow.selected = gameObject;
		uiTimer = uiDuration;
		hipsterUI.SetActive(false);
		hipsterInfo.SetActive(true);
	}

	public void DeselectHipster () {
		hipsterInfo.SetActive(false);
		CameraFollow.selected = CameraFollow.lastWizardSelected;
	}
}
