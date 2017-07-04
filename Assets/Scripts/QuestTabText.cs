using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTabText : MonoBehaviour {

	public GameObject questTab;

	void Start () {
		LoadQuestText();
	}
	
	void OnEnable () {
		LoadQuestText();
	}

	void LoadQuestText () {
		Quest tabText = questTab.GetComponent<QuestTab> ().tabQuest;
		if (tabText.questDescription == null) {
			gameObject.GetComponent<Text> ().text = null;
		} else {
			gameObject.GetComponent<Text> ().text = tabText.questDescription;
		}
	}
}
