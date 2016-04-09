using UnityEngine;
using System.Collections.Generic;
using System.Linq;

// This is placed on the furthes player away, so place the
// camera as a parent of the gameobject that has this script
public class OutOfScreenManager : MonoBehaviour {

	public List<Health> Players = new List<Health>();

	private void PositionAtFurthersPlayer() {
		var z = Players.Max(health => health.gameObject.transform.position.z);
		var p = this.transform.position;
		this.transform.position = new Vector3(p.x, p.y, z);
	}

	private void KillPlayersWhoAreOutside() {
		foreach(var p in this.Players) {
			var z = p.gameObject.transform.position.z;
			if( z < CameraUtil.CameraPositionBottom ) {
				p.GetOutsideOfWorld();
			}
		}

		// remove players who have died?
	}

	void Update () {
		this.PositionAtFurthersPlayer();
		this.KillPlayersWhoAreOutside();
	}
}
