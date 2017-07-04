using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTab : MonoBehaviour {

	public int tabID;
	public Quest tabQuest;

	void Start() {
		LoadQuest();
	}

	void OnEnable() {
		LoadQuest();
	}

	void LoadQuest() {
		tabQuest = CameraFollow.selected.GetComponent<QuestManager>().activeQuests[tabID];
		if (tabQuest.questDescription == null) {
			gameObject.GetComponent<Image> ().enabled = false;
		} else {
			gameObject.GetComponent<Image> ().enabled = true;
		}
	}
}
