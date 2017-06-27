using UnityEngine;
using System.Collections;

public class WizardSettings : MonoBehaviour {

	public static int inventorySize = 60;
	public static int inventoryColumns = 10;
	public int inventoryTotal;
	public bool inventoryFull = false;
	public int moneyTotal;
	public int starsTotal;
	public static int questSize = 6;

	void Start(){
		//reset totals on start
		inventoryTotal = 0;
		moneyTotal = 0;
		starsTotal = 0;
	}
}
