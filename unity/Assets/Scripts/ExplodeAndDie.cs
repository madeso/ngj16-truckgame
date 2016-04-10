using UnityEngine;
using System.Collections;

public class ExplodeAndDie : MonoBehaviour {
	public GameObject Explosion;
	public float TimeUntilDeath = 2f;
	public float ExplosionIntervalMin = 0.08f;
	public float ExplosionIntervalMax = 0.16f;

	private Health health;
	private float timer = 0.0f;

	void Start () {
		this.health = this.GetComponent<Health>();
	}

	private float ExplosionInterval {
		get {
			return Random.Range(this.ExplosionIntervalMin, this.ExplosionIntervalMax);
		}
	}
	
	void Update () {
		if( this.health.IsAlive ) {
			return;
		}

		this.TimeUntilDeath -= Time.deltaTime;

		if( this.TimeUntilDeath <= 0.0f ) {
			Destroy(this.gameObject);
		}

		this.timer -= Time.deltaTime;
		if( this.timer <= 0.0f ) {
			this.timer += this.ExplosionInterval;

			// todo: fix random position
			var o = GameObject.Instantiate(this.Explosion);
			o.transform.position = this.transform.position + Random.insideUnitSphere * 2.0f;

			// don't use physics for theese...
			foreach(var ep in o.GetComponents<ExplosionPhysics>()) {
				ep.enabled = false;
			}
		}
	}
}
