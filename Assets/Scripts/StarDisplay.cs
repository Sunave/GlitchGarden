using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private static Text starText;
	private static int totalStars;

	void Start () {
		starText = GetComponent<Text>();
		UpdateView();
	}

	public void AddStars (int amount) {
		totalStars += amount;
		UpdateView();
	}

	public void UseStars (int amount) {
		totalStars -= amount;
		UpdateView();
	}

	private void UpdateView () {
		starText.text = totalStars.ToString();
	}
}
