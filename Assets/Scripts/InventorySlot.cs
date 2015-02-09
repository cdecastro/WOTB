using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventorySlot : MonoBehaviour {

	public int slotId;
	public Item slotItem;
	public GameObject slotIcon;
	public GameObject slotText;

	void Start() {
		LoadItem();
	}

	void OnEnable() {
		LoadItem();
	}

	void LoadItem() {
		slotItem = CameraFollow.selected.GetComponent<Inventory>().inventory[slotId];
		if (slotItem.itemIcon == null) {
			slotIcon.GetComponent<Image>().enabled = false;
		} else {
			slotIcon.GetComponent<Image>().enabled = true;
			slotIcon.GetComponent<Image>().sprite = slotItem.itemIcon;
		}
		slotText.GetComponent<Text>().text = slotItem.itemName;
	}
}
