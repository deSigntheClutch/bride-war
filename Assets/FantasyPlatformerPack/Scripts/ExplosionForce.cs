using UnityEngine;
using System.Collections;

public class ExplosionForce : MonoBehaviour {

	public float explosionForce = 4;
	public float exposionRadius = 1;

	void Start () {
		gameObject.GetComponent<Rigidbody>().AddExplosionForce
			(explosionForce, transform.position, exposionRadius);
	}

}
