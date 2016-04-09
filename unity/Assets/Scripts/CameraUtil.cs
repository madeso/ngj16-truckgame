using UnityEngine;
using System.Collections;

public static class CameraUtil {
	private static float VariableCameraPosition(float x) {
		var c = Camera.main;
		var r = c.ScreenPointToRay(new Vector3(0,c.pixelHeight * x,0));
		var t = -r.origin.y / r.direction.y; // find t where y=0
		var p = r.GetPoint(t);
		return p.z;
	}

	public static float CameraPositionBottom {
		get {
			return  VariableCameraPosition(0.0f);
		}
	}

	public static float CameraPositionTop {
		get {
			return VariableCameraPosition(1.0f);
		}
	}
}
