using UnityEngine;
using System.Collections;
using InControl;

public class Controller
{
    public InputDevice inputDevice;
    public int roleId = -1;
    public int truckId = -1;

    public Controller (InputDevice device)
    {
        inputDevice = device;
    }

    public bool isRoleAssigned {
        get {
            return roleId != -1;
        }
    }

    public bool isTruckAssigned {
        get {
            return truckId != -1;
        }
    }
}
