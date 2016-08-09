using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class HeroMovement : MonoBehaviour
{
	
	public float speed = 0.1f;
	private Animator animator;

	void Start ()
	{

		animator = GetComponent<Animator> ();

	}


	void FixedUpdate ()
	{
		float input_x = Input.GetAxisRaw ("Horizontal");
		float input_y = Input.GetAxisRaw ("Vertical");

		bool isWalking = (Mathf.Abs (input_x) + Mathf.Abs (input_y)) > 0;

		animator.SetBool ("isWalking", isWalking);

		if (isWalking) {
			animator.SetFloat ("x", input_x);
			animator.SetFloat ("y", input_y);

			transform.position += new Vector3 (input_x, input_y, 0).normalized * Time.deltaTime * 5;
		}
	}
}
