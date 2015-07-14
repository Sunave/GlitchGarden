using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;
	
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if (musicManager) {
			musicManager.SetVolume(PlayerPrefsManager.GetMasterVolume());
		} else {
			Debug.LogWarning("MusicManager not found");
		}
	}

}
