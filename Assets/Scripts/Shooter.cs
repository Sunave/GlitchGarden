using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;

	private GameObject projectileParent;
	private GameObject gun;
	private Animator animator;
	private AttackerSpawner thisRowSpawner;
	
	void Start () {

		animator = GetComponent<Animator>();
		FindThisRowSpawner();

		// Find a Gun child
		if (gameObject.transform.Find("Gun")) {
			gun = gameObject.transform.Find("Gun").gameObject;
		} else Debug.LogError ("You need to create a child named 'Gun' for " + name);

		// Find a parent to put projectiles into, or create one
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent) projectileParent = new GameObject("Projectiles");

	}


	void Update () {
		if (AttackerAheadInLane()) {
			animator.SetBool( "isAttacking", true);
		} else {
			animator.SetBool( "isAttacking", false);
		}
	}

	bool AttackerAheadInLane () {
		if (thisRowSpawner.transform.childCount <= 0 ) return false;

		foreach(Transform attacker in thisRowSpawner.transform) {
			if (gameObject.transform.position.x < attacker.transform.position.x) return true;
		}

		return false;
	}

	// Look through all spawners, and set thisRowSpawner if found
	void FindThisRowSpawner () {
		AttackerSpawner[] spawners = GameObject.FindObjectsOfType<AttackerSpawner>();
		foreach (AttackerSpawner spawner in spawners) {
			if (transform.position.y == spawner.transform.position.y) {
				thisRowSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in lane " + transform.position.y);
	}

	private void FireGun() {
		GameObject newProjectile = Instantiate (projectile, gun.transform.position, Quaternion.identity) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
	}
}
