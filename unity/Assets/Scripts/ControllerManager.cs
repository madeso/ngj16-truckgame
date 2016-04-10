using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InControl;


public class ControllerManager : MonoBehaviour {

	public RectTransform player1Icon;
	public RectTransform player2Icon;

    [SerializeField]
    private GameObject[] trucks;
    private List<Controller> controllers = new List<Controller>();


	private Controller truck1Controller;
	private Controller truck2Controller;


    void Start()
    {
    }
	private void updatePlayerIcon(Controller controller){
		
		RectTransform icon = null;
		if(controller.player == 0){
			icon = player1Icon;
		}else if(controller.player == 1){
			icon = player2Icon;
		}
		if(icon != null){

			float offset = 200.0f;
			
			Vector2 v = icon.anchoredPosition;
			if(truck1Controller == controller){
				v.x = -offset;
			}else if(truck2Controller == controller){

				v.x = offset;

			}else{
				v.x = 0.0f;
			}
			icon.anchoredPosition = v;
		}
	}
    // Update is called once per frame
	void Update () {
        foreach(InputDevice device in InputManager.Devices){
            if (FindControllerByInputDevice(device) == null) {
                // New device spotted
				int player = controllers.Count;
				print("attached controller"+device.Meta+ " to player "+player);
				controllers.Add(new Controller(device, player));
				//print(device.Meta);
            }
            Controller activeController = FindControllerByInputDevice(device);
            if (device.DPadLeft.IsPressed){
				if(truck1Controller == null && truck2Controller != activeController){
					activeController.roleId = 0;
					print("set player"+activeController.player+" to left");
					AssignController(0, activeController);
				}
            } else if (device.DPadRight.IsPressed) {
				if(truck2Controller == null && truck1Controller != activeController){
					activeController.roleId = 0;
					print("set player"+activeController.player+" to right");
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
		print("truckId:"+truckId + " player:" +controller.player);
		if(truckId == 0){
			truck1Controller = controller;

			updatePlayerIcon(controller);
		}
		else if(truckId == 1) {
			truck2Controller = controller;
			//print(controller.inputDevice.Meta);
			updatePlayerIcon(controller);
		}
		
		if(truck1Controller != null & truck2Controller != null){
			
			//starts the trucks
			trucks[0].GetComponent<TruckController>().Controller = truck1Controller;
			trucks[0].GetComponent<ShootingTestControl>().Controller = truck1Controller;

			trucks[1].GetComponent<TruckController>().Controller = truck2Controller;
			trucks[1].GetComponent<ShootingTestControl>().Controller = truck2Controller;
			player1Icon.gameObject.SetActive(false);
			player2Icon.gameObject.SetActive(false);
		}
	}

    private void StartGame(){
        gameObject.SetActive(false);
    }
}
