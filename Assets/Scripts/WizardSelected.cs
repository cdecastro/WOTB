﻿using UnityEngine;
using System.Collections;

public class WizardSelected : MonoBehaviour {
	
	public string playerTag = "Player";
	public string wizardTag = "Wizard";
	public GameObject tapToSelect;
	public GameObject wizardUI;
	public GameObject wizardInfo;
	public GameObject inventoryUI;
	public GameObject waypoint;
	private NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		TurnOnSelectionOption();
	}

	void Update () {
		if (waypoint.activeSelf == true) {
			wizardUI.SetActive(false);
			wizardInfo.SetActive(false);
			inventoryUI.SetActive(false);
			tapToSelect.SetActive(false);
		}

		if (CameraFollow.selected != gameObject){
			agent.ResetPath();
			agent.radius = 1f;
			gameObject.GetComponent<PlayerNav>().enabled = false;
			TurnOnSelectionOption();
		} 
	}

	public void SelectWizard () {
		CameraFollow.selected = gameObject;
		gameObject.tag = playerTag;
		gameObject.GetComponent<PlayerNav>().enabled = true;
		waypoint.SetActive(false);
		tapToSelect.SetActive(false);
		wizardUI.SetActive(true);
	}

	public void TurnOnWizardInfo () {
		wizardUI.SetActive(false);
		wizardInfo.SetActive(true);
	}

	public void TurnOffWizardInfo () {
		wizardInfo.SetActive(false);
	}

	public void TurnOnInventoryUI () {
		inventoryUI.SetActive(true);
		wizardUI.SetActive(false);
	}
	
	public void TurnOffInventoryUI () {
		inventoryUI.SetActive(false);
	}

	void TurnOnSelectionOption () {
		gameObject.tag = wizardTag;
		tapToSelect.SetActive(true);
		wizardUI.SetActive(false);
		wizardInfo.SetActive(false);
		inventoryUI.SetActive(false);
	}

}