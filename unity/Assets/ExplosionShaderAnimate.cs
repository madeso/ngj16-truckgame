using UnityEngine;
using System.Collections;

public class ExplosionShaderAnimate : MonoBehaviour {



	public float loopDuration;
	public float fadeDuration;

	Renderer rend;
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		float r = Mathf.Sin((Time.time / loopDuration) * (2 * Mathf.PI)) * 0.5f + 0.25f;
		float g = Mathf.Sin((Time.time / loopDuration + 0.33333333f) * 2 * Mathf.PI) * 0.5f + 0.25f;
		float b = Mathf.Sin((Time.time / loopDuration + 0.66666667f) * 2 * Mathf.PI) * 0.5f + 0.25f;
		float correction = 1 / (r + g + b);
		r *= correction;
		g *= correction;
		b *= correction;
		rend.material.SetVector("_ChannelFactor", new Vector4(r,g,b,0));

		float timePercent = Time.time/fadeDuration;
		//rend.material.SetVector("_Range", new Vector4(0, 1 - (Time.time / fadeDuration)));
		float range = (Time.time / fadeDuration);
		rend.material.SetVector("_Range", new Vector4(timePercent,1));
		rend.material.SetFloat("_Displacement", 0.1f+(timePercent*0.9f));
		//rend.material.SetFloat("_ClipRange", 1 - (Time.time / fadeDuration));
		float scaler = timePercent*8.0f;
		transform.localScale.Scale(new Vector3(scaler,scaler,scaler));
		if(timePercent>1.4){
			Destroy(gameObject);
		}
	}
}
