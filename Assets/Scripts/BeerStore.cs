using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BeerStore : MonoBehaviour {

	public GameObject canImage;
	public GameObject totalText;
	public GameObject wizard;
	public int total;
	Item can;
	Animator anim;
	int processCanHash = Animator.StringToHash("ProcessCan");
	Text text;


	void Start () {
		anim = canImage.GetComponent<Animator>();
		canImage.GetComponent<Image>().enabled = false;
		text = totalText.GetComponent<Text>();
		wizard = CameraFollow.lastWizardSelected;
	}

	void Update () {
		string formattedTotal = (total*0.01).ToString("0.00");
		text.text = "TOTAL $" + formattedTotal;
	}
	
	void OnEnable () {
		total = 0;
		wizard = CameraFollow.lastWizardSelected;
//		canImage.GetComponent<Image>().enabled = false;
	}

	public void TriggerSellCans () {
		StartCoroutine(SellCans());
	}
	IEnumerator SellCans () {
		List<Item> wizardInventory = wizard.GetComponent<Inventory>().inventory;
		for (int i = 0; i < wizardInventory.Count; i++) {
			if (wizardInventory[i].itemType == Item.ItemType.Can) {
				can = wizardInventory[i];
				wizardInventory[i] = new Item();
				total += can.itemPrice;
				wizard.GetComponent<WizardSettings>().moneyTotal += can.itemPrice;
				wizard.GetComponent<WizardSettings>().inventoryTotal--;
				CanProcess(can);
				yield break;
			}
		}
	}

	void CanProcess (Item can) {
		canImage.GetComponent<Image>().sprite = can.itemIcon;
		anim.SetTrigger(processCanHash);
		wizard.GetComponent<Inventory>().CleanUpInventory();
	}
}
