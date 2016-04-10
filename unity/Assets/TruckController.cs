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

    void Start () {
        Health.OnPlayerDied += OnPlayerDied;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (device != null){
			var sp = this.m_Car.CurrentSpeed / this.m_Car.MaxSpeed;
            float steering = device.LeftStick.X * turnRate;
			m_Car.Move(steering * (1.2f - sp), acceleration, acceleration, 0);
        }
	}

    void OnPlayerDied(GameObject player) {
        device = null;
    }

    void OnDestroy () {
        Health.OnPlayerDied -= OnPlayerDied;
    }
}
