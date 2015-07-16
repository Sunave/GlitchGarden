using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject parent;

	void Start () {
		parent = GameObject.Find ("Defenders");
		if (!parent) parent = new GameObject("Defenders");
	}

	void OnMouseDown () {
		Vector2 position = SnapToGrid(CalculateWorldPointOfMouseClick());
		GameObject defender = Instantiate (Button.selectedDefender, position, Quaternion.identity) as GameObject;
		defender.transform.parent = parent.transform;

	}

	Vector2 SnapToGrid (Vector2 source) {
		return new Vector2 (Mathf.RoundToInt(source.x), Mathf.RoundToInt(source.y));
	}

	Vector2 CalculateWorldPointOfMouseClick () {
		return Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
