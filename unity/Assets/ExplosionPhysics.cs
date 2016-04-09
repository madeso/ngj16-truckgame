using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExplosionPhysics : MonoBehaviour {


	public float radius = 5.0F;
	public float power = 10.0F;
	public float upwardsModifier = 3.0f;

	//NB: only applies force to active rigid bodies. /ts
	void Start() {
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		foreach (Collider hit in colliders) {
			Rigidbody rb = hit.GetComponent<Rigidbody>();

			if (rb != null)
				rb.AddExplosionForce(power, explosionPos, radius, upwardsModifier);

		}
	}
}
