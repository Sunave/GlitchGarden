using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

	private Text starText;
	private int totalStars = 100;
	public enum Status {SUCCESS, FAILURE};

	void Start () {
		starText = GetComponent<Text>();
		UpdateView();
	}

	public void AddStars (int amount) {
		totalStars += amount;
		UpdateView();
	}

	public Status UseStars (int amount) {
		if (totalStars >= amount) {
			totalStars -= amount;
			UpdateView();
			return Status.SUCCESS;
		} 
		return Status.FAILURE;
	}

	private void UpdateView () {
		starText.text = totalStars.ToString();
	}

	public void ResetStars () {
		totalStars = 0;
	}
}
