using UnityEngine;
using System.Collections;

[System.Serializable]
public class Quest {
	//quest name
	//quest ID
	//quest description
	//quest Type
	//quest Cost
	//quest Item
	//quest Target
	public string questName;
	public int questID;
	public string questDescription;
	public QuestType questType;
	public int questCost;
	public Item questItem;
	public GameObject questTarget;

	public enum QuestType {
		Pay,
		Get,
		Give
	}

	public Quest(string name, int id, string description, QuestType type, int cost, Item item, GameObject obj) {
		questName = name;
		questID = id;
		questDescription = description;
		questCost = cost;
		questType = type;
		questItem = item;
		questTarget = obj;
	}

	public Quest(){

	}

}
