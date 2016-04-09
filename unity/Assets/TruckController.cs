using UnityEngine;
using System.Collections;
using InControl;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof (CarController))]
public class TruckController : MonoBehaviour {

    private CarController m_Car; // the car controller we want to use
    [SerializeField]
    private float acceleration = 40;
    [SerializeField]
    private float turnRate = 15f;
    [SerializeField]
    private float maxTurnAngle = 50f;

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
	void Awake () {
        // get the car controller
        m_Car = GetComponent<CarController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (device != null){
            float steering = device.LeftStick.X * turnRate;
            m_Car.Move(steering, acceleration, acceleration, 0);
        }
	}
}
