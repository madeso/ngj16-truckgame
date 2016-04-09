using UnityEngine;
using System.Collections;
using InControl;


public class CubeController : MonoBehaviour {

    void Start()
    {
        
        /*foreach (InputDevice o in InputManager.Devices)
        {
            Debug.Log("Controller Detected");
        }
        */
    }

        // Update is called once per frame
        void Update () {

        var InputDevice0 = InputManager.ActiveDevice;
        transform.Rotate(Vector3.down, 500.0f * Time.deltaTime * InputDevice0.LeftStickX, Space.World);
        transform.Rotate(Vector3.right, 500.0f * Time.deltaTime * InputDevice0.LeftStickY, Space.World);
    }
}
