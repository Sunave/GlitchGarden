using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public bool autoLoadNextLevel;
	public float autoLoadNextLevelAfter;

	void Start () {
		if (autoLoadNextLevel) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		}
	}

	public void LoadLevel (string name) {
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void QuitRequest () {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel () {
		Application.LoadLevel(Application.loadedLevel + 1);
	}


}
