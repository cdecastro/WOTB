using UnityEngine;
using System.Collections;

public class CanPop : MonoBehaviour {

	public float explosiveForce = 0f;
	public float explosiveRadius = 10f;
	public Transform sourcePosition;

	void Start () {
		rigidbody.AddExplosionForce(explosiveForce, sourcePosition.position, explosiveRadius);
	}

}
