using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	public GameObject[] attackerPrefabs;

	private GameObject parent;

	// Use this for initialization
	void Start () {
		parent = GameObject.Find("Attackers");
		if (!parent) parent = new GameObject("Attackers");
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject attacker in attackerPrefabs) {
			if (isTimeToSpawn (attacker)) {
				Spawn (attacker);
			}
		}
	}

	bool isTimeToSpawn (GameObject attackerPrefab) {
		float threshold = (1 / attackerPrefab.GetComponent<Attacker>().seenEverySeconds) * Time.deltaTime / 5;
		return Random.value < threshold;
	}

	void Spawn (GameObject attackerPrefab) {
		GameObject attacker = Instantiate (attackerPrefab, transform.position, Quaternion.identity) as GameObject;
		attacker.transform.parent = transform;
	}
}
