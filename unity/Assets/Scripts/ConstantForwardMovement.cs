using UnityEngine;
using System.Collections;

public class ConstantForwardMovement : MonoBehaviour {
	private Health health;

	public float Speed = 1.0f;

	void Start () {
		this.health = GetComponent<Health>();
	}
	
	void Update () {
		if( this.health.IsAlive ) {
			this.transform.position += this.transform.forward * Time.deltaTime * this.Speed;
		}
	}
}
