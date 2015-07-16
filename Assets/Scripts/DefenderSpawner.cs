using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;
	private StarDisplay starDisplay;

	void Start () {
		parent = GameObject.Find ("Defenders");
		if (!parent) parent = new GameObject("Defenders");

		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}

	void OnMouseDown () {
		Vector2 position = SnapToGrid(CalculateWorldPointOfMouseClick());
		GameObject defenderType = Button.selectedDefender;

		int defenderCost = defenderType.GetComponent<Defender>().starCost;
		if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS) {
			SpawnDefender (defenderType, position);
		} else Debug.Log ("Insufficient stars to spawn");
	}

	void SpawnDefender (GameObject defenderType, Vector2 position)
	{
		GameObject newDefender = Instantiate (defenderType, position, Quaternion.identity) as GameObject;
		newDefender.transform.parent = parent.transform;
	}
	

	Vector2 SnapToGrid (Vector2 source) {
		return new Vector2 (Mathf.RoundToInt(source.x), Mathf.RoundToInt(source.y));
	}

	Vector2 CalculateWorldPointOfMouseClick () {
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
