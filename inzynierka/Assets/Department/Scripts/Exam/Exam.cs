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
	private Button goBackToMenuButton;

	private int correctAnswers;

	private int currentQuestionNumber;

	void Start(){
		textComponents = this.GetComponentsInChildren<Text> ();
	    buttonComponents = this.GetComponentsInChildren<Button> ();

		cheatButton = buttonComponents [0];
		shootButton = buttonComponents [1];
		moveButton = buttonComponents [2];
		goBackToMenuButton = buttonComponents [3];

		goBackToMenuButton.gameObject.SetActive (false);

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
			if (DoesHeroKnowAnswer ()) {
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


	private bool DoesHeroKnowAnswer(){

		Random.Range (0f, 50f);

		// wiedza max 10 pkt * 5


		float points = Stats.Knowledge * 5 + Random.Range (0f, 50f);

		Debug.Log ("points " + points);


		if (points > 60) {
			correctAnswers++;
			return true;
		} else {
			return false;
		}


	}

	private bool DoesCheatSucced(){

		Random.Range (0f, 50f);

		// cheat max 10 pkt * 5


		float points = Stats.Cheating * 5 + Random.Range (0f, 50f);

		Debug.Log ("points " + points);

		if (points > 60) {
			correctAnswers++;
			return true;
		} else {
			return false;
		}


	}

	private bool DoesShootSucced(){


		//  4 odpowiedzi = 25%


		float points = Random.Range (0f, 100f);

		Debug.Log ("points " + points);



		if (points > 50) {
			correctAnswers++;
			return true;
		} else {
			return false;
		}


	}

	public void ChangeQuestion(){

		currentQuestionNumber++;


		shootButton.interactable = false;
		cheatButton.interactable = false;
		moveButton.interactable = false;

		Debug.Log ("current question NUmber = " + currentQuestionNumber);

		// tu dać text z nastepnego pytania
		if (currentQuestionNumber > questionsNumber) {
			
			if (correctAnswers == 1) {
				if (questionsNumber / 2 <= correctAnswers) {
					textComponents [0].text = "koniec egzaminu. Postać odpowiedziała poprawnie: " + correctAnswers + " raz. Na " +
						questionsNumber + " pytań. Zdałeś egzamin. Koniec gry, udaj się do menu, aby zagrać ponownie.";
				} else {
					
					textComponents [0].text = "koniec egzaminu. Postać odpowiedziała poprawnie: " + correctAnswers + " raz. Na " +
						questionsNumber + " pytań. Nie Zdałeś egzaminu. Koniec gry, udaj się do menu, aby zagrać ponownie.";
				}
			} else {
				if (questionsNumber / 2 <= correctAnswers) {
					textComponents [0].text = "koniec egzaminu. Postać odpowiedziała poprawnie: " + correctAnswers + " razy. Na " +
						questionsNumber + " pytań. Zdałeś egzamin. Koniec gry, udaj się do menu, aby zagrać ponownie.";
				} else {

					textComponents [0].text = "koniec egzaminu. Postać odpowiedziała poprawnie: " + correctAnswers + " razy. Na " +
						questionsNumber + " pytań. Nie Zdałeś egzaminu. Koniec gry, udaj się do menu, aby zagrać ponownie.";
				}
			}

			shootButton.interactable = false;
			cheatButton.interactable = false;
			moveButton.interactable = false;
			textComponents [4].text = "";
			goBackToMenuButton.gameObject.SetActive (true);

	
		}
		else{
			changedTextOfThisQuestion = false;

			textComponents [0].text = "bla bla";

		}


	


		Debug.Log ("teraz pytanie numer = " + currentQuestionNumber);

		if (currentQuestionNumber > questionsNumber) {

			// zmiana sceny do wyniku
		}

	}

	public void Cheat(){

		// changedTextOfThisQuestion = false;

		shootButton.interactable = false;
		cheatButton.interactable = false;
		moveButton.interactable = false;

		bool cheatSucced = DoesCheatSucced ();

		Debug.Log ("cheat udało się " + cheatSucced);

		if (!cheatSucced) {

			textComponents [0].text = "Zostałeś przyłapany na ściąganiu. Nie zdałeś egzaminu.";

			goBackToMenuButton.gameObject.SetActive (true);

		} else {
			textComponents [4].text = "Udało Ci się sciągnąć !";
			moveButton.interactable = true;
		}
	

		Debug.Log ("teraz pytanie numer = " + currentQuestionNumber);

		if (currentQuestionNumber > questionsNumber) {

			// zmiana sceny do wyniku
		}

	}


	public void Shoot(){

		// changedTextOfThisQuestion = false;

		shootButton.interactable = false;
		cheatButton.interactable = false;

		bool shootSucced = DoesShootSucced ();

		Debug.Log ("Strzał się udał? " + shootSucced);

		moveButton.interactable = true;


	}


	public void GoToMenu(){

		Application.LoadLevel ("Menu");

	}



}
