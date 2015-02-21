using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {
	public List<Item> inventory = new List<Item>();
	private ItemDatabase database;

	void Start () {
		for (int i = 0; i < WizardSettings.inventorySize; i++) {
			inventory.Add (new Item());
		}
		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

		// test database
//		AddItem(1);
//		AddItem(2);
//		AddItem(1);
//		AddItem(2);
//		AddItem(1);
//		AddItem(2);
//		AddItem(1);
//		AddItem(2);
//		AddItem(1);
//		AddItem(2);
//		AddItem(1);
//		AddItem(2);
//		AddItem(1);
//		AddItem(2);
//		AddItem(1);
//		AddItem(2);
//		inventory[5] = new Item();
//		inventory[7] = new Item();
//		inventory[11] = new Item();



	}

//	void OnGUI () { //debug list, turn off for final build
//		// on screen inventory list
//		for(int i = 0; i < inventory.Count; i++) {
//			GUI.Label(new Rect(10,20 + (i * 10), 200, 50), inventory[i].itemName);
//		}
//	}

	public void AddItem(int id) {
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory[i].itemName == null) {
				for (int j = 0; j < database.items.Count; j++) {
					if (database.items[j].itemID == id) {
						inventory[i] = database.items[j];
					}
				}
				break;
			}
		}
	}

	public void CleanUpInventory() {
		// find items that aren't null write to new temp list
		List<Item> tempList = new List<Item>();
		for (int i = 0; i < inventory.Count; i++) {
			if (inventory[i].itemName != null) {
				tempList.Add (inventory[i]);
			}
		}
		// add in empty list items to match current inventory count
		for (int j = tempList.Count; j < inventory.Count; j++) {
			tempList.Add (new Item());
		}
		// write new inventory from temp list
		for (int k = 0; k < inventory.Count; k++) {
			inventory[k] = tempList[k];
		}
	}
}
