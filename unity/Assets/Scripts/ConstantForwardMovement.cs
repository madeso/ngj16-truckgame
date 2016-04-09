using UnityEngine;
using System.Collections;

public class ConstantForwardMovement : MonoBehaviour {

	public float Speed = 1.0f;

	void Start () {}
	
	void Update () {
		this.transform.position += this.transform.forward * Time.deltaTime * this.Speed;
	}
}
