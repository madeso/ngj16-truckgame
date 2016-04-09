using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class VisibleInEditor : MonoBehaviour {
	// Update is called once per frame
	void OnRenderObject () {
		Debug.DrawLine(this.transform.position, this.transform.position + this.transform.up * 3);
	}
}
