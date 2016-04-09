using UnityEngine;
using System.Collections.Generic;

public class World : MonoBehaviour {

	public GameObject[] Parts;
	public float TerrainBias = 0.01f; // the ammount the terrain is allowed to overlap

	private GameObject RandomPart {
		get {
			var i = Random.Range(0, Parts.Length);
			return Parts[i];
		}
	}

	private List<GameObject> alive = new List<GameObject>(); // ordered from first y to last y

	private static float WidthOf(GameObject p) {
		// todo: determine actual size
		var t = p.gameObject.GetComponentInChildren<Terrain>();
		return t.terrainData.size.z;
	}

	private static float TopOf(GameObject p) {
		return p.transform.position.z + WidthOf(p) / 2.0f;
	}

	private float EmptyZ {
		get {
			return transform.position.z - 400;
		}
	}

	private float EndPosition {
		get {
			var last = this.alive.Count-1;
			if( last < 0 ) {
				// no items, means the end pos is way back
				return this.EmptyZ;
			}
			return TopOf(this.alive[last]) - this.TerrainBias;
		}
	}

	private float FirstPosition {
		get {
			if( this.alive.Count <=0 ) {
				// no items, means the start pos is way back
				return this.EmptyZ;
			}
			return TopOf(this.alive[0]);
		}
	}

	private int SpawnParts () {
		var spawned = 0;

		var end = this.EndPosition;
		if (CameraUtil.CameraPositionTop > end) {
			var p = GameObject.Instantiate (this.RandomPart);
			var v = new Vector3 (this.transform.position.x - WidthOf(p) / 2.0f, this.transform.position.y, end + WidthOf (p) / 2.0f);
			this.alive.Add (p);
			p.transform.position = v;
			++spawned;
		}
		if (CameraUtil.CameraPositionBottom > this.FirstPosition) {
			// destroy first
		}

		return spawned;
	}

	void Start () {
		var spawned = 0;
		do {
			spawned = SpawnParts();
		} while(spawned > 0 );
	}
	
	void Update () {
		SpawnParts ();
	}
}
