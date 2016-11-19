using UnityEngine;
using System.Collections;

public class DestroyCanvasIfExists : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int currentBubblesCount = (GameObject.FindGameObjectsWithTag ("Bubble")).Length;

		if (currentBubblesCount > 0) {
			GameObject canvas = GameObject.FindGameObjectWithTag ("Canvas When Entered The Class");
			if (canvas != null) {
				Destroy (canvas);
			}

		}


	}
}
