using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public float autoLoadNextLevelAfter;

	void Start () {
		if (autoLoadNextLevelAfter > 0) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		} else if (autoLoadNextLevelAfter < 0) {
			Debug.LogWarning("Level auto load disabled, you should use a positive number in seconds");
		}
	}

	public void LoadLevel (string name) {
		Application.LoadLevel (name);
	}

	public void QuitRequest () {
		Application.Quit ();
	}

	public void LoadNextLevel () {
		Application.LoadLevel(Application.loadedLevel + 1);
	}


}
