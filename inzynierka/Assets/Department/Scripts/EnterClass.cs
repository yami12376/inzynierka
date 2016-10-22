using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
			}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Hero") {
			// 
			GameObject classNumber = GameObject.FindGameObjectWithTag(this.gameObject.tag+" Number");
			Debug.Log (classNumber);

			Debug.Log ("test kolizji");
			Debug.Log(this.gameObject.tag);

			Text classNumberText = GameObject.FindGameObjectWithTag(this.gameObject.tag+" Number").
				GetComponentInChildren<Text>();

			Debug.Log (classNumberText.text);

		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
