using UnityEngine;
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
			//shotPower = Mathf.Min(maxShotPower, shotPower);
			//print("charging shot:"+shotPower);
		}

	}
	public void DoShoot(){
		isShotCharging = false;
		print("Shooting with power: "+shotPower);
		Rigidbody instantiatedProjectile = Instantiate(projectile,spawnPosition.position,barrel.rotation)as Rigidbody;
		instantiatedProjectile.AddForce(spawnPosition.forward*shotPower);
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
