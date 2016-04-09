using UnityEngine;
using System.Collections;

public class ShootingTestControl : MonoBehaviour {
	private Shooting shootComponent;
	// Use this for initialization
	void Start () {
		shootComponent = GetComponent<Shooting>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			shootComponent.ChargeShot();
		}
		if(Input.GetButtonUp("Fire1")){
			shootComponent.DoShoot();
		}
		shootComponent.barrel.Rotate(0, Input.GetAxis("Horizontal")*shootComponent.RotateSpeed*Time.deltaTime, 0);
	}
}
