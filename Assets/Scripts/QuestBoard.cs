using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBoard : MonoBehaviour {


	public GameObject questTabPrefab;

	void Start () {
		for (int i = 0; i < WizardSettings.questSize; i++) {
			GameObject questTab = Instantiate(questTabPrefab) as GameObject;
			questTab.transform.SetParent(transform,false);
			questTab.GetComponent<QuestTab>().tabID = i;
		}
	}
}
