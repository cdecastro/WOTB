using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HipsterNav : MonoBehaviour {
	
	public GameObject cube; // game model
	public GameObject party;
	public GameObject spawn;
	public Color defaultColor;
	public Color selectedColor;
	public string playerTag = "Player";
	public string hipsterTag = "Hipster";
	public string spawnTag = "Spawn";
	public float drinkDuration = 12f;
	public int drinks = 1;
	public float canSpawnRadius = 0.75f;
	public float canSpawnHeight = 1f;
	
	private UnityEngine.AI.NavMeshAgent agent;
	private Vector3 destination;
	private Material mat;
	[SerializeField] float drinkTimer = 0f;
	public bool drinking = false;
	private bool inSpawn = true;
	private bool goingHome = false;

	private ItemDatabase database;
	[SerializeField] Item drinkType;
	public int drinkRangeStart = 0;
	public int drinkRangeEnd = 5;
	[SerializeField] int drinkID;

	void Start () {
		// find item database and chose random drink, set as drinkType
		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
		drinkID = Random.Range(drinkRangeStart, drinkRangeEnd+1);
		for (int i = 0; i < database.items.Count; i++) {
			if (database.items[i].itemID == drinkID) {
				drinkType = database.items[i];
				break;
			}
		}
		// set default color
		mat = cube.GetComponent<Renderer>().material;
		mat.color = defaultColor;

		//set drinks
		drinks += Random.Range(1, 3);

		// set destination
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		destination = party.transform.position;
		agent.SetDestination(destination);
	}
	
	void Update () {

		// drink timer
		if (drinkTimer > 0f && drinks > 0) {
			drinkTimer -= Time.deltaTime;
			if (drinkTimer <= 0f && drinking == true) {
				// done drinking? make a can
				MakeCan();
				// have more drinks? keep drinking
				Drink();
			}
		}

		// out of drinks?
		if (drinks == 0 && drinking == true) {
			Headhome();
		}
	
	}

	void OnTriggerStay (Collider other) {

		// destroy object when reaching spawn point
		if (other.CompareTag(spawnTag) && goingHome == true) {
			CameraFollow.selected = CameraFollow.lastWizardSelected;
			Destroy(gameObject);
		}

		// meet hipster who has drinks
		if (other.CompareTag(hipsterTag) && drinks > 0 && drinking == false && inSpawn == false) {
			int hasDrinks = other.GetComponent<HipsterNav>().drinks;
			if (hasDrinks > 0) {
				// start drinking
				agent.ResetPath();
				Drink();
			}
		}
	}

	void OnTriggerExit (Collider other) {

		// leaving spawnpoint
		if (other.CompareTag(spawnTag)) {
			inSpawn = false;
		}
	}

	void Drink () {
		// start drink timer
		drinkDuration += Random.Range (-1f, 1f);
		drinkTimer = drinkDuration;
		drinking = true;
		// change to drinking color
		mat.color = selectedColor;
	}

	void MakeCan () {
		// minus a drink
		drinks -= 1;
		// find spawn point
		Vector3 canSpawn = new Vector3 (
			(transform.position.x + Random.Range(-canSpawnRadius, canSpawnRadius)), 
			(transform.position.y + canSpawnHeight), 
			(transform.position.z + Random.Range(-canSpawnRadius, -canSpawnRadius))
			);
		// create can
		GameObject madeCan = Instantiate(drinkType.itemObj, canSpawn, Quaternion.identity) as GameObject;
		// can settings
		madeCan.GetComponent<CanSetting>().canItem = drinkType;
		madeCan.GetComponent<CanPop>().sourcePosition =  gameObject.transform;
	}

	void Headhome () {
		// set destination to spawn home
		destination = spawn.transform.position;
		agent.SetDestination(destination);
		drinking = false;
		goingHome = true;
		// set color to default
		mat.color = defaultColor;
	}
}
