using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;
	
	void Start () {
		Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
	}

	void Update () {
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log (name + " trigger entered by " + collider);
	}

	public void setSpeed (float speed) {
		currentSpeed = speed;
	}

	// Called from the animator at the time of actual blow
	public void StrikeCurrentTarget (float damage) {
		Debug.Log(name + " strikes for " + damage + " damage!");
	}

	public void Attack (GameObject target) {
		currentTarget = target;

	}
	
}
