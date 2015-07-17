using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public static GameObject selectedDefender;

	public GameObject defenderPrefab;

	private Button[] buttonArray;
	private Text costText;

	
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();
		GetComponent<SpriteRenderer>().color = Color.black;

		costText = transform.GetComponentInChildren<Text>();
		if (!costText) Debug.LogWarning ("Add a child with Text element for Button " + name);
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}

	void OnMouseDown () {

		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}

		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
