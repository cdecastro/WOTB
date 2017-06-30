using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTab : MonoBehaviour {

	public int tabID;
	public Quest tabQuest;
	public GameObject tabText;

	void Start() {
		LoadQuest();
	}

	void OnEnable() {
		LoadQuest();
	}

	void LoadQuest() {
		tabQuest = CameraFollow.selected.GetComponent<QuestManager>().activeQuests[tabID];
		if (tabQuest.questDescription == null) {
			tabText.GetComponent<Text> ().text = "";
		} else {
			tabText.GetComponent<Text> ().text = tabQuest.questDescription;
		}
	}
}
