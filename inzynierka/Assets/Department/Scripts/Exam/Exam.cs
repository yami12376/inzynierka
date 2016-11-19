using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exam : MonoBehaviour {

	public float questionsNumber;

	// Update is called once per frame
	void Update () {
		Text textComponent = this.GetComponentInChildren<Text> ();
		string text = textComponent.text;
		char questionNumber = text [0];
		Debug.Log ("number = " + questionNumber);

		Debug.Log("cheatStat = " + Stats.Cheating);
		Debug.Log("Wisdomtat = " + Stats.Knowledge);

		
	}
}
