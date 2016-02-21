using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerNav : MonoBehaviour {

	public GameObject waypoint;
	public GameObject cube;
	public float dizzyDuration = 2f;
	public float knockbackForce = 20f;
	public float knockbackRadius = 20f;
	public Color defaultColor;
	public Color selectedColor;
	public string npcTag = "Hipster";
	public string canTag = "Can";
	public string playerTag = "Player";
	public string dizzyTag = "Dizzy";
	public GameObject can;
	public float canPopForce = 15f;
//	public int cansInv = 0;

	private NavMeshAgent agent;
	private Vector3 destination;
	public bool dizzy;
	private float dizzyTimer;
	private Material mat;

	private Inventory wizardInventory;
	private WizardSettings wizardSettings;

	void Start() {
		wizardInventory = GetComponent<Inventory>();
		wizardSettings = GetComponent<WizardSettings>();
		agent = GetComponent<NavMeshAgent>();
		dizzy = false;
		dizzyTimer = 0f;
		mat = cube.GetComponent<Renderer>().material;
	}

	void Update() {

		// dizzy mechanic
		if (dizzyTimer > 0f){
			dizzy = true;
			gameObject.tag = dizzyTag;
			dizzyTimer -= Time.deltaTime;
			mat.color = selectedColor;
		} else {
			dizzy = false;
			gameObject.tag = playerTag;
			mat.color = defaultColor;
		}

		// find waypoint
		if (waypoint.activeSelf == true && dizzy == false) {
			destination = waypoint.transform.position;
			agent.SetDestination(destination);
			agent.radius = 0.5f;
		} else {
			agent.ResetPath();
			agent.radius = 1f;
		}
	}

	void OnCollisionEnter(Collision collision) {

		// player collision
		if(collision.gameObject.CompareTag(npcTag) && dizzy == false) {
			// start knockdown timer
			dizzyTimer = dizzyDuration;
			// disable waypoint
			waypoint.SetActive(false);
			// add knockback force
			GetComponent<Rigidbody>().AddExplosionForce(knockbackForce, collision.transform.position, knockbackRadius);
			// count cans to lose
			if (wizardSettings.inventoryTotal > 0) {
				int canLoss = Mathf.Clamp((wizardSettings.inventoryTotal / 2), 1, 20);
				for (int i = 0; i < canLoss; i++) {
					MakeCan(); // lose # of cans
				}
			}
		}

		// pickup can
		if(collision.gameObject.CompareTag(canTag) && wizardSettings.inventoryTotal < WizardSettings.inventorySize) {
			//add can to inventory
			wizardSettings.inventoryTotal++;
			Item canItem = collision.gameObject.GetComponent<CanSetting>().canItem;
			int id = canItem.itemID;
			wizardInventory.AddItem(id);
			Destroy(collision.gameObject, 0f);
		}
	}

	void MakeCan () {
		// minus can from inv
		wizardSettings.inventoryTotal--;
		// find the last item in the inventory
		Item canType = new Item();
		int inventorySize = wizardInventory.inventory.Count -1;
		for (int j = inventorySize; j >= 0; j--) {
			if (wizardInventory.inventory[j].itemName != null) {
				canType = wizardInventory.inventory[j] as Item;
				wizardInventory.inventory[j] = new Item();
				break;
			}
		}

		// find can position
		Vector3 canSpawn = new Vector3 (
			(transform.position.x + Random.Range(-0.5f, 0.5f)), 
			(transform.position.y + 1.5f), 
			(transform.position.z + Random.Range(-0.5f, 0.5f))
			);

		// make can
		GameObject madeCan = Instantiate(canType.itemObj, canSpawn, Quaternion.identity) as GameObject;
		madeCan.GetComponent<CanSetting>().canItem = canType;
		madeCan.GetComponent<CanPop>().sourcePosition = gameObject.transform;
		madeCan.GetComponent<CanPop>().explosiveForce = canPopForce;
	}
}
