using UnityEngine;
using System.Collections.Generic;

public class WorldPart : MonoBehaviour {

	public List<GameObject> SpawnLocations;
	public GameObject Cactus;
	public int Count = 2;

	void Start () {
		if( this.SpawnLocations == null ) return;
		if( this.SpawnLocations.Count == 0 ) return;

		for(int i=0; i< this.Count; ++i) {
			var id = Random.Range(0, this.SpawnLocations.Count);
			var c = GameObject.Instantiate(this.Cactus);
			c.transform.position = this.SpawnLocations[id].transform.position;
			c.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.up);

			this.SpawnLocations.RemoveAt(id);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
