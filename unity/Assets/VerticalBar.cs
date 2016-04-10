using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VerticalBar : MonoBehaviour {

	private float originalRectHeight;
	private RectTransform r;
	// Use this for initialization
	void Start () {
		r = GetComponent<RectTransform>();
		originalRectHeight = r.sizeDelta.y;
	}
	public void SetValue(float value){
		print("value:"+value);
		float newHeight = originalRectHeight*value;
		print("newHeight:"+newHeight);
		r.sizeDelta = new Vector2(r.sizeDelta.x, newHeight);
	}
	// Update is called once per frame
	void Update () {
		SetValue(0.5f);
	}
}
