using UnityEngine;
using System.Collections.Generic;

public class WorldPart : MonoBehaviour {

	public List<GameObject> SpawnLocations;
	public GameObject Cactus;
	public GameObject Stone;
	public int Count = 2;

	void Start () {
		if( this.SpawnLocations == null ) return;
		if( this.SpawnLocations.Count == 0 ) return;

		if( this.Cactus != null ) SpawnObjects (this.Count, this.Cactus, 0);
		if( this.Stone != null ) SpawnObjects (1, this.Stone, 8);
	}

	void SpawnObjects (int count, GameObject go, float x)
	{
		for (int i = 0; i < count; ++i) {
			var id = Random.Range (0, this.SpawnLocations.Count);
			var c = GameObject.Instantiate (go);
			var p = this.SpawnLocations [id].transform.position;
			p.y += x;
			c.transform.position = p;
			c.transform.rotation = Quaternion.AngleAxis (Random.Range (0, 360), Vector3.up);
			this.SpawnLocations.RemoveAt (id);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
