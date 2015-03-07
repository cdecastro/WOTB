using UnityEngine;
using System.Collections;

public class CanPop : MonoBehaviour {

	public float explosiveForce = 0f;
	public float explosiveRadius = 10f;
	public Transform sourcePosition;

	void Start () {
		GetComponent<Rigidbody>().AddExplosionForce(explosiveForce, sourcePosition.position, explosiveRadius);
	}

}
