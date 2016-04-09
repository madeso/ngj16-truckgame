using UnityEngine;
using System.Collections;

public class DrivingControls : MonoBehaviour {

    [SerializeField]
    private float acceleration = 40;
    [SerializeField]
    private float friction = 4;
    [SerializeField]
    private float turnRate = 15f;

    private float maxSpeed;

    private new Rigidbody rigidbody;

    // Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        maxSpeed = acceleration / friction;
	}
	
	void FixedUpdate () {
        float input = Input.GetAxis("Vertical") * acceleration;
        var locVel = transform.InverseTransformDirection(rigidbody.velocity);
        locVel -= locVel * friction * Time.deltaTime;
        locVel.z += input * Time.deltaTime;
        rigidbody.velocity = transform.TransformDirection(locVel);

        float steering = Input.GetAxis("Horizontal") * turnRate * (locVel.magnitude / maxSpeed);
        transform.Rotate(Vector3.up, steering);
	}
}
