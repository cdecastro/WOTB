using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	Vector3 startingMenuPosition;
	Vector3 startingCameraPosition;

	public GameObject title;
	public GameObject street;
//	public GameObject navigation;
//	public GameObject stores;
	public GameObject home;
	public GameObject beerStore;
	public GameObject cornerStore;
	public GameObject parkButton;
	public GameObject closeInventoryUI;
//	public GameObject homeButton;
//	public GameObject storesButton;
//	public GameObject navigationButton;

	[SerializeField] string menuTag = "MenuWindow";
	[SerializeField] string storeTag = "StoreWindow";
	[SerializeField] string homeTag = "HomeWindow";

	void Start () {
		//variables for menus follow camera
		startingMenuPosition = transform.position;
		startingCameraPosition = Camera.main.transform.position;
		//startup menus
		MenuStartup();
	}

	void Update () {
		// turn off button if window is enabled
//		navigationButton.SetActive(!navigation.activeSelf);
//		storesButton.SetActive(!stores.activeSelf);
// 		homeButton.SetActive(!home.activeSelf);
	}

	void LateUpdate () {
		//menus follow camera
		transform.position = startingMenuPosition + (Camera.main.transform.position - startingCameraPosition);
	}

	void MenuStartup () {
//		TurnOffAllMenus();
		TurnOffAllSubMenus();
		title.SetActive(true);
//		navigation.SetActive(true);
	}
//
//	void TurnOffAllMenus () {
//		GameObject[] menus;
//		menus = GameObject.FindGameObjectsWithTag(menuTag);
//		foreach (GameObject menu in menus) {
//			menu.SetActive(false);
//		}
//	}
//
	public void TurnOffAllSubMenus () {
		GameObject[] storeMenus;
		storeMenus = GameObject.FindGameObjectsWithTag(storeTag);
		foreach (GameObject store in storeMenus) {
			store.SetActive(false);
		}

		GameObject[] homeMenus;
		homeMenus = GameObject.FindGameObjectsWithTag(homeTag);
		foreach (GameObject home in homeMenus) {
			home.SetActive(false);
		}
	}

//	public void GoToNavigation () {
//		TurnOffAllMenus();
//		TurnOffAllSubMenus();
//		navigation.SetActive(true);
//	}

//	public void GoToStores () {
//		TurnOffAllMenus();
//		TurnOffAllSubMenus();
//		stores.SetActive(true);
//	}

	public void GoToBeerStore () {
		if (!beerStore.activeSelf) {
			TurnOffAllSubMenus();
			beerStore.SetActive(true);
			closeInventoryUI.SetActive(true);
		}
	}

	public void GoToCornerStore () {
		if (!cornerStore.activeSelf) {
			TurnOffAllSubMenus();
			cornerStore.SetActive(true);
			closeInventoryUI.SetActive(true);
		}
	}

	public void GoHome () {
//		TurnOffAllMenus();
		if (!home.activeSelf) {
			TurnOffAllSubMenus();
			home.SetActive(true);
			closeInventoryUI.SetActive(true);
		}
	}
		
	public void TurnOffTitle () {
		title.SetActive(false);
	}
}
