using UnityEngine;
using System.Collections;

public class ShootingTestControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			print("fire");
			/*
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(startPos);
			if(collider.Raycast(ray,out hit, 10000.0f)){

				Debug.Log( "Hit detected on object " + name + " at point " + hit.point );
				if(hit.transform.gameObject == collider.gameObject){
				}
			}
			*/
		}
	}
}
