using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnterClass : MonoBehaviour
{
	public GameObject canvasWhenEnteredToTheClass;

	// Use this for initialization
	void Start ()
	{
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		if (collider.gameObject.tag == "Hero") {
			// 
			GameObject classNumber = GameObject.FindGameObjectWithTag (this.gameObject.tag + " Number");
			Debug.Log (classNumber);

			Debug.Log ("test kolizji");
			Debug.Log (this.gameObject.tag);

			Text classNumberText = GameObject.FindGameObjectWithTag (this.gameObject.tag + " Number").
				GetComponentInChildren<Text> ();

			Debug.Log (classNumberText.text);

			if (classNumberText.text == "sala2005") {
		
				GameObject entryCanvas = GameObject.FindGameObjectWithTag ("Entry Canvas");
				if (entryCanvas != null) {
					Destroy (entryCanvas);
				}

				GameObject spawnedCanvas = Instantiate (canvasWhenEnteredToTheClass, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;

			}


		}
	}

	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
