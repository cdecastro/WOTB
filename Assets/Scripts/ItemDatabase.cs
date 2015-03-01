using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item>();
	public GameObject can;

	void Start () {
		// do not write an item with item ID = 0

		// beer cans use ID range 1-99
		items.Add(new Item("Pabst", 1, "The Blue Ribbon", 5, Item.ItemType.Can, can));
		items.Add(new Item("Steamwhistle", 2, "Green Can with the whistle", 5, Item.ItemType.Can, can));
		items.Add(new Item("MillSt", 3, "It's Organic!", 5, Item.ItemType.Can, can));
		items.Add(new Item("Creemore", 4, "A river runs through it...", 5, Item.ItemType.Can, can));
		items.Add(new Item("Amsterdam", 5, "Tall & Blonde", 5, Item.ItemType.Can, can));

		// recyclables use ID range 100-199

	}


}
