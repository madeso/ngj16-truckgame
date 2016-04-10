using UnityEngine;
using System.Collections;
using InControl;

public class ShootingTestControl : MonoBehaviour {
	private Shooting shootComponent;

    private Controller controller;
    private InputDevice device;

    public Controller Controller {
        get {
            return controller;
        }
        set {
            controller = value;
            device = controller.inputDevice;
        }
    }

	// Use this for initialization
	void Start () {
		shootComponent = GetComponent<Shooting>();
	}
	
	// Update is called once per frame
	void Update () {
        if (device != null){
            if(device.RightBumper.IsPressed){
                shootComponent.ChargeShot();
            }
            if(device.RightBumper.WasReleased){
                shootComponent.DoShoot();
            }

			shootComponent.barrel.Rotate(0,0,device.RightStick.X * shootComponent.RotateSpeed * Time.deltaTime);
        } else {
			/*
            if (Input.GetButtonDown("Fire1")){
                shootComponent.ChargeShot();
            }
            if (Input.GetButtonUp("Fire1")){
                shootComponent.DoShoot();
            }
			shootComponent.barrel.Rotate(0,0,Input.GetAxis("Horizontal")*shootComponent.RotateSpeed*Time.deltaTime);*/
        }
	}
}
