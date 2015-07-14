using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D collider) {

		GameObject colliderObject = collider.gameObject;

		// Leave method if not colliding with defender
		if (!colliderObject.GetComponent<Defender>()) {
			return;
		}

		if (colliderObject.GetComponent<Stone>()) {
			animator.SetTrigger ("jumpTrigger");
		} else {
			animator.SetBool ("isAttacking", true);
			attacker.Attack (colliderObject);
		}

	}
}
