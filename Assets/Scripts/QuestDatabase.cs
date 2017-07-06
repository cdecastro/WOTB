using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDatabase : MonoBehaviour {
	public List<Quest> quests = new List<Quest> ();

	void Start () {
		quests.Add( new Quest("Pay Hydro", 1, "Hydro Bill is overdue", Quest.QuestType.Pay, 35, null, null));
		quests.Add( new Quest("Pay Cable", 2, "Cable Bill is overdue", Quest.QuestType.Pay, 35, null, null));
		quests.Add( new Quest("Pay Phone", 3, "Phone Bill is overdue", Quest.QuestType.Pay, 35, null, null));
	}
}
