using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;


public class CubeController : MonoBehaviour {

    [SerializeField]
    private Transform[] cubes;
    private List<Controller> controllers = new List<Controller>();

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
        

        foreach(InputDevice device in InputManager.Devices){
            if (FindControllerByInputDevice(device) == null) {
                // New device spotted
                controllers.Add(new Controller(device));
            }
            Controller activeController = FindControllerByInputDevice(device);
            if (device.LeftStick.X < 0f){
                // Pointing left
                if (device.LeftStick.Y < 0f){
                    // Pointing up
                    activeController.roleId = 0;
                } else if (device.LeftStick.Y > 0f){
                    // Pointing down
                    activeController.roleId = 1;
                }
            } else if (device.LeftStick.X > 0f) {
                // Pointing right
                if (device.LeftStick.Y < 0f){
                    // Pointing up
                    activeController.roleId = 2;
                } else if (device.LeftStick.Y > 0f){
                    // Pointing down
                    activeController.roleId = 3;
                }
            }
            
            if (device.Action1.IsPressed) {
//                Debug.Log("Action1");
                if (activeController.isRoleAssigned) {
                    Debug.Log(activeController.roleId);
                    if (activeController.roleId < cubes.Length) {
                        cubes[activeController.roleId].transform.Rotate(Vector3.up, 50f);
                    }
                }
            }
        }
    }

    private Controller FindControllerByInputDevice (InputDevice inputDevice) {
        return controllers.Find((Controller controller) => {return controller.inputDevice == inputDevice;});
    }
}
