using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public List<Quest> activeQuests = new List<Quest>();
	private QuestDatabase database;

	// list of active quests
	// add quest to list
	// quest logic
	// execute quest rewards
	// remove quest


	void Start () {
		for (int i = 0; i < WizardSettings.questSize; i++) {
			activeQuests.Add (new Quest());
		}
		database = GameObject.FindGameObjectWithTag("QuestDatabase").GetComponent<QuestDatabase>();

	}

	public void AddQuest(int id) {
		//check if the quest is active
		bool isQuestActive = false;
		for (int k = 0; k < activeQuests.Count; k++) {
			if (activeQuests [k].questID == id) {
				isQuestActive = true;
			}
		}
		//if so, add the quest in the next availble slot
		if (isQuestActive == false) {
			for (int i = 0; i < activeQuests.Count; i++) {
				if (activeQuests[i].questName == null) {
					for (int j = 0; j < database.quests.Count; j++) {
						if (database.quests[j].questID == id) {
							activeQuests[i] = database.quests[j];
						}
					}
					break;
				}
			}
		}
	}

	public void RemoveQuest(int id) {
		for (int i = 0; i < activeQuests.Count; i++) {
			if (activeQuests[i].questID == id) {
				activeQuests[i] = null;
			}
		}
	}

}
