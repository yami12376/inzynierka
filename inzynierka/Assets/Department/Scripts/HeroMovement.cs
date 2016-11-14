using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class HeroMovement : MonoBehaviour
{
	
	public float speed = 0.1f;
	private Animator animator;
	private bool running;
	private float defaultSpeed;

	void Start ()
	{
		animator = GetComponent<Animator> ();
		defaultSpeed = speed;
	}

	void FixedUpdate ()
	{
		if (Input.GetKey (KeyCode.LeftShift)) {
			running = true;
		} else if (!Input.GetKey (KeyCode.LeftShift)) {
			running = false;
		}


		if (running) {
			speed = defaultSpeed * 2;
		} else {
			speed = defaultSpeed;
		}
			
		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");

		bool isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;

		int currentBubblesCount = (GameObject.FindGameObjectsWithTag ("Bubble")).Length;

		Debug.Log ("isWalking: " + isWalking);
		Debug.Log ("count " + currentBubblesCount);

		if (isWalking && currentBubblesCount < 1) {
			animator.SetBool ("isWalking", isWalking);
			animator.SetFloat ("x", input_x);
			animator.SetFloat ("y", input_y);

			transform.position += new Vector3 (input_x, input_y, 0).normalized * Time.deltaTime * speed;
		} else if (isWalking == false) {
			animator.SetBool ("isWalking", isWalking);
		}
	}
}
