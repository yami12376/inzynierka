using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Exam : MonoBehaviour {

	public int questionsNumber;
	private bool changedTextOfThisQuestion;

	private Text[] textComponents;
	private Button[] buttonComponents;

	private Button cheatButton;
	private Button shootButton;
	private Button moveButton;

	private int currentQuestionNumber;

	void Start(){
		textComponents = this.GetComponentsInChildren<Text> ();
	    buttonComponents = this.GetComponentsInChildren<Button> ();

		cheatButton = buttonComponents [0];
		shootButton = buttonComponents [1];
		moveButton = buttonComponents [2];

		currentQuestionNumber = 1;
	}
		
	// Update is called once per frame
	void Update () {
		
		Text textComponent = textComponents [0];
		Text knowAnswerText = textComponents [4];

		string text = textComponent.text;
		char questionNumber = text [0];
		Debug.Log ("number = " + questionNumber);

		Debug.Log("cheatStat = " + Stats.Cheating);
		Debug.Log("Wisdomtat = " + Stats.Knowledge);



		if (!changedTextOfThisQuestion) {
			changedTextOfThisQuestion = true;
			if (doesHeroKnowAnswer ()) {
				Debug.Log ("zna");
				knowAnswerText.text = "Postać zna odpowiedź";
				moveButton.interactable = true;

			} else {
				Debug.Log ("nie zna");
				knowAnswerText.text = "Postać nie zna odpowiedzi";
				shootButton.interactable = true;
				cheatButton.interactable = true;
			}
		}

		
	}


	private bool doesHeroKnowAnswer(){

		Random.Range (0f, 50f);

		// wiedza max 10 pkt * 5


		float points = Stats.Knowledge * 5 + Random.Range (0f, 50f);

		Debug.Log ("points " + points);

		points += 45;

		if (points > 60) {
			return true;
		} else {
			return false;
		}


	}

	public void changeQuestion(){

		textComponents [0].text = "bla bla";


		changedTextOfThisQuestion = false;

		shootButton.interactable = false;
		cheatButton.interactable = false;
		moveButton.interactable = false;

		currentQuestionNumber++;

		Debug.Log ("teraz pytanie numer = " + currentQuestionNumber);

		if (currentQuestionNumber > questionsNumber) {

			// zmiana sceny do wyniku
		}

	}


}
