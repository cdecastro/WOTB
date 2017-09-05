using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public List<Quest> activeQuests = new List<Quest>();
	private QuestDatabase database;
	private bool isQuestActive = false;

	// list of active quests
	// add quest to list
	// quest logic
	// execute quest rewards
	// remove quest


	void Start () {
		database = GameObject.FindGameObjectWithTag("QuestDatabase").GetComponent<QuestDatabase>();
		for (int i = 0; i < WizardSettings.questSize; i++) {
			activeQuests.Add (new Quest());
		}
	}

	public void AddQuest(int id) {
		//check if the quest is active
		isQuestActive = false;
		for (int k = 0; k < activeQuests.Count; k++) {
			if (activeQuests[k].questID == id) {
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
			if (activeQuests [i].questID == id) {
					activeQuests [i] = new Quest();
			}			
		}
	}

	public void MoneyQuest(int pay) {
		//find wizard money
		int money = GetComponent<WizardSettings> ().moneyTotal;
		//check money
		if (pay <= money) {
			//remove money
			GetComponent<WizardSettings> ().moneyTotal -= pay;
			// quest achieved
		} else {
			// not enough money dialogue
		}
	}

//	IEnumerator ItemQuest (Item item) {
//		List<Item> wizardInventory = GetComponent<Inventory>().inventory;
//		for (int i = 0; i < wizardInventory.Count; i++) {
//			if (wizardInventory[i] == item) {
//				//
//			}
//		}
//	}


	//find wizard inventory
	//check inventory for item
	//check inventory for room
	//remove from inventory

	//reward money
	//reward item
	//reward token

	//confirm or insufficent dialogue box

}
