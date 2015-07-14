using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)]	public float walkSpeed;
	
	void Start () {
		Rigidbody2D rigidBody = gameObject.AddComponent<Rigidbody2D>();
		rigidBody.isKinematic = true;
	}

	void Update () {
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log (name + " trigger entered by " + collider);
	}
}
