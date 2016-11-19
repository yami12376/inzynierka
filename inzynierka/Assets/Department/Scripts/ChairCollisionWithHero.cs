using UnityEngine;
using System.Collections;

public class ChairCollisionWithHero : MonoBehaviour
{

	void OnCollisionEnter (Collision col)
	{
		Debug.Log ("przeniesienie do sceny egzaminu 1.");
		if (col.gameObject.tag == "Hero") {
			Debug.Log ("przeniesienie do sceny egzaminu 2.");
		}
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Debug.Log ("przeniesienie do sceny egzaminu 1.");
		if (collider.gameObject.tag == "Hero") {

			Debug.Log ("przeniesienie do sceny egzaminu 2.");
			Debug.Log ("cheat: " + Stats.Cheating);
		}
	}

}
