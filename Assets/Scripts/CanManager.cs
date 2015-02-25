using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanManager : MonoBehaviour {

//	public GameObject player;
//	public static int cansMade;
	Text text;

	void Awake () {
	
		text = GetComponent<Text> ();
	}
	
	void Update () {
//		int cans = player.GetComponent<PlayerNav>().cansInv;
		int cans = CameraFollow.lastWizardSelected.GetComponent<WizardSettings>().inventoryTotal;
		int capacity = CameraFollow.lastWizardSelected.GetComponent<Inventory>().inventory.Count;
		int money = CameraFollow.lastWizardSelected.GetComponent<WizardSettings>().moneyTotal;
		int stars = CameraFollow.lastWizardSelected.GetComponent<WizardSettings>().starsTotal;
		string player = CameraFollow.selected.gameObject.name;
		string formattedMoney = (money*0.01).ToString("0.00");
		text.text = cans+"/"+capacity+" $"+formattedMoney+" "+player;
	
	}
}
