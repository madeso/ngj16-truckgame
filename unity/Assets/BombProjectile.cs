using UnityEngine;
using System.Collections;

public class BombProjectile : MonoBehaviour {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		var go = other.gameObject;
		if( go != null ) {
            var h = go.GetComponentInParent<Health>();
			if( h != null ) {
				h.IncreaseLeakRate( 10 );
			}
		}
		Instantiate(explosion,transform.position,transform.rotation);
		Destroy(gameObject);
	}
}
