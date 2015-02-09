using UnityEngine;
using System.Collections;

public class CanSetting : MonoBehaviour {

	public Item canItem;
	public GameObject canModel;

	void Start () {
		Texture canTexture = Resources.Load<Texture>("ItemTextures/" + canItem.itemName+"_tex");
		canModel.renderer.material.mainTexture = canTexture;
	}
}
