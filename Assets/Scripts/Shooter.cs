using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	private GameObject projectileParent;
	private GameObject gun;
	
	void Start () {

		// Find a Gun child
		if (gameObject.transform.Find("Gun")) {
			gun = gameObject.transform.Find("Gun").gameObject;
		} else Debug.LogError ("You need to create a child named 'Gun' for " + name);

		// Find a parent to put projectiles into, or create one
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent) projectileParent = new GameObject("Projectiles");
	}

	private void FireGun() {
		GameObject newProjectile = Instantiate (projectile, gun.transform.position, Quaternion.identity) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		//newProjectile.transform.position = gun.transform.position;
	}
}
