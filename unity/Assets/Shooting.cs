﻿using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {


	public Transform barrel;
	public Transform spawnPosition;
	public float RotateSpeed = 0.4f;
	public float shotChargePower = 10.0f;
	public float maxShotPower = 1000.0f;
	public Rigidbody referenceRigidBody;
	public Rigidbody projectile;

	private bool isShotCharging = false;
	private float shotPower = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(isShotCharging){
			shotPower=shotPower + shotChargePower;
			shotPower = Mathf.Min(maxShotPower, shotPower);
			//print("charging shot:"+shotPower);
		}

	}
	public void DoShoot(){
		isShotCharging = false;
		print("Shooting with power: "+shotPower);

		var r = barrel.rotation;
		//r = r * Quaternion.AngleAxis(90, Vector3.right);

		Rigidbody instantiatedProjectile = Instantiate(projectile,spawnPosition.position,r)as Rigidbody;
		var dir = spawnPosition.forward;
		dir.y -= 0.2f;
		instantiatedProjectile.AddForce(dir*shotPower);
		if(referenceRigidBody != null){
			instantiatedProjectile.GetComponent<Rigidbody>().velocity = referenceRigidBody.velocity;
		}
		//instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,shotPower));
	}
	public void ChargeShot(){
		if(!isShotCharging){
			isShotCharging = true;
			shotPower = 0;	
		}

	}
}
