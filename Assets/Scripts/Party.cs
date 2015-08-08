using UnityEngine;
using System.Collections;

public class Party : MonoBehaviour {

	public GameObject hipster;			//hipster to spawn
	public GameObject player;			//player
	public float playerRange = 12f;		//distance to player to activate party
	public int activateOdds = 4;		//odds of activation / 10
	public GameObject[] spawnPoints;	//spawn points array
	public float timer = 0f;			//shared timer gizmo
	public bool scanEnable = false;		//start scanning for player
	public int hipstersToSpawn = 0;		//number of hipsters to spawn
	public int hipstersMaxSpawn = 6;	//possible # of hipsters +1 to spawn
	public float activateTimer = 5f;	//timer duration for activation
	public float spawnTimer = 2f; 		//timer duration for spawns


	void Start () {
		//activate at begining
//		Activate();
		scanEnable = false;
		hipstersToSpawn = Random.Range(1 ,hipstersMaxSpawn) + 1;
		SpawnHipster();
	}
	
	void Update () {
		//timer, if >0 run timer
		if(timer > 0f) {
			timer -= Time.deltaTime; 
		}

		//if timer <=0,  scanEnable =true
		if(timer <= 0f) { 
		   if(scanEnable == true) {
				//scan distance to player, if true run roll to activate
				float dist = Vector3.Distance(transform.position, player.transform.position);
//				Debug.Log (gameObject.name + " "dist);
				if (dist < playerRange) {
					Activate();
				}
			} else {
				SpawnHipster();
			}
		}
	}

	void Activate () {
//		Debug.Log(gameObject.name + " activate");
		//roll to activate
		int roll = Random.Range(1 , 10);

		//if successful scanEnable = false, roll # hipsters, run spawn
		if(roll <= activateOdds) {
			// Debug.Log("Make Hipsters!");
			scanEnable = false;
			hipstersToSpawn = Random.Range(1 ,hipstersMaxSpawn) + 1;
			SpawnHipster();
		
		//else set timer to activate time
		} else {
			// Debug.Log("Fail Hipsters");
			scanEnable = true;
			timer = activateTimer;
		}
	}

	void SpawnHipster () {
		// Debug.Log("spawn hipster");

		//check # hipsters
		//if # hipsters <= 0, scanEnable = true
		if(hipstersToSpawn <= 0) {
			// Debug.Log("reset");

			scanEnable = true;
		//else, if timer <= 0 
		} else {
			// Debug.Log("spawn");

			//set timer to spawn time
			timer = spawnTimer + Random.Range(0f, 1f);
			// Debug.Log("set timer");

			//chose spawn point
			int randomPoint = Random.Range(0, spawnPoints.Length);
			// Debug.Log("chose spawn point" + randomPoint);

			//create hipster
			Vector3 randomPosition = new Vector3(Random.Range(-2.0F, 2.0F), 0, Random.Range(-2.0F, 2.0F));
			GameObject hipsterInstance = Instantiate(hipster, (spawnPoints[randomPoint].transform.position + randomPosition), Quaternion.identity) as GameObject;
			// Debug.Log("create hipster");

			//set spawn point
			hipsterInstance.GetComponent<HipsterNav>().spawn = spawnPoints[randomPoint];
			// Debug.Log("set spawnpoint");

			//set party
			hipsterInstance.GetComponent<HipsterNav>().party = this.gameObject;
			// Debug.Log("set party");

			//-1 hipster
			hipstersToSpawn -= 1;
			// Debug.Log("- hipster");

			
			//+1 to activate time
//			activateTimer += 2f;
			// Debug.Log("add time");

		}
	}
}
