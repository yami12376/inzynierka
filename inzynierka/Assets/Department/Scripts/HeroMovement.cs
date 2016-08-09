using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class HeroMovement : MonoBehaviour
{
	
	public float speed = 0.1f;


	void FixedUpdate ()
	{
		if (Input.GetKey ("up"))
			this.GetComponent<Transform> ().transform.position += new Vector3 (0, speed, 0);

		if (Input.GetKey ("down"))
			this.GetComponent<Transform> ().transform.position -= new Vector3 (0, speed, 0);

		if (Input.GetKey ("left"))
			this.GetComponent<Transform> ().transform.position -= new Vector3 (speed, 0, 0);

		if (Input.GetKey ("right"))
			this.GetComponent<Transform> ().transform.position += new Vector3 (speed, 0, 0);
	}
}
