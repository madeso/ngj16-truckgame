using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;


public class ControllerManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] trucks;
    private List<Controller> controllers = new List<Controller>();

    void Start()
    {
    }

        // Update is called once per frame
        void Update () {
        foreach(InputDevice device in InputManager.Devices){
            if (FindControllerByInputDevice(device) == null) {
                // New device spotted
                controllers.Add(new Controller(device));
            }
            Controller activeController = FindControllerByInputDevice(device);
            if (device.DPadLeft.IsPressed){
                // Pointing left
                if (device.DPadDown.IsPressed){
                    // Pointing up
                    activeController.roleId = 0;
                    AssignController(0, activeController);
                } else if (device.DPadUp.IsPressed){
                    // Pointing down
                    activeController.roleId = 1;
                    AssignController(0, activeController);
                }
            } else if (device.DPadRight.IsPressed) {
                // Pointing right
                if (device.DPadLeft.IsPressed){
                    // Pointing up
                    activeController.roleId = 0;
                    AssignController(1, activeController);
                } else if (device.DPadRight.IsPressed){
                    // Pointing down
                    activeController.roleId = 1;
                    AssignController(1, activeController);
                }
            }

            if (device.MenuWasPressed) {
                StartGame();
            }
        }
    }

    private Controller FindControllerByInputDevice (InputDevice inputDevice) {
        return controllers.Find((Controller controller) => {return controller.inputDevice == inputDevice;});
    }

    private void AssignController(int truckId, Controller controller){
        if (truckId >= trucks.Length){
            return;
        }
        trucks[truckId].GetComponent<TruckController>().Controller = controller;
    }

    private void StartGame(){
        gameObject.SetActive(false);
    }
}
