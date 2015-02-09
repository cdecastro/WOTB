using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item {
	public string itemName;
	public int itemID;
	public string itemDescription;
	public Sprite itemIcon;
	public int itemPrice;
	public ItemType itemType;
	public GameObject itemObj;

	public enum ItemType {
		Null,
		Can,
		Recyclable,
		Food,
		Junk
	}

	public Item(string name, int id, string description, int price, ItemType type, GameObject obj) {
		itemName = name;
		itemID = id;
		itemDescription = description;
		itemPrice = price;
		itemType = type;
		itemIcon = Resources.Load<Sprite>("ItemIcons/" + name+"_icon");
		itemObj = obj;
	}
	public Item(){

	}
}
