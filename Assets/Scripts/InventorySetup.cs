using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InventorySetup : MonoBehaviour {

	public GameObject inventorySlotPrefab;

	void Start () {
		for (int i = 0; i < WizardSettings.inventorySize; i++) {
			GameObject inventorySlot = Instantiate(inventorySlotPrefab) as GameObject;
			inventorySlot.transform.SetParent(transform,false);
			inventorySlot.GetComponent<InventorySlot>().slotId = i;
		}
		gameObject.GetComponent<GridLayoutGroup>().constraintCount = WizardSettings.inventoryColumns;
	}
}
