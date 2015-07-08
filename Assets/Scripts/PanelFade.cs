using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PanelFade : MonoBehaviour {

	public float fadeInTime;

	void Awake () {
		GetComponent<Image>().color = Color.black;
	}
	
	void Start () {
		GetComponent<Image>().CrossFadeAlpha(0f, fadeInTime, false);
	}

	void Update () {
		if (Time.timeSinceLevelLoad >= fadeInTime) {
			gameObject.SetActive (false);
		}
	}

}
