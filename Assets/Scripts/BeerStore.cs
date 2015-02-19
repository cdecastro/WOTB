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
		text.text = "TOTAL:" + total*0.01f;
	}
	
	void OnEnable () {
		total = 0;
		wizard = CameraFollow.lastWizardSelected;
	}

	public void SellCans () {
		List<Item> wizardInventory = wizard.GetComponent<Inventory>().inventory;
		for (int i = 0; i < wizardInventory.Count; i++) {
			if (wizardInventory[i].itemType == Item.ItemType.Can) {
				can = wizardInventory[i];
				wizardInventory[i] = null;
				total += can.itemPrice;
				wizard.GetComponent<WizardSettings>().moneyTotal += can.itemPrice;
				wizard.GetComponent<WizardSettings>().inventoryTotal--;
				CanProcess(can);
			}
		}
	}

	void CanProcess (Item can) {
		canImage.GetComponent<Image>().sprite = can.itemIcon;
		anim.SetTrigger(processCanHash);
	}
}
