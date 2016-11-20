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

	private string[] correctAnswersArray;

	void Start(){
		textComponents = this.GetComponentsInChildren<Text> ();
	    buttonComponents = this.GetComponentsInChildren<Button> ();

		cheatButton = buttonComponents [0];
		shootButton = buttonComponents [1];
		moveButton = buttonComponents [2];
		goBackToMenuButton = buttonComponents [3];

		goBackToMenuButton.gameObject.SetActive (false);



		currentQuestionNumber = 1;
		Debug.Log ("teraz pytanie numer = " + currentQuestionNumber);


		correctAnswersArray = new string[3]{"d","b","b"};
	}
		
	// Update is called once per frame
	void Update () {
		
		Text textComponent = textComponents [0];
		Text knowAnswerText = textComponents [4];

		string text = textComponent.text;
		char questionNumber = text [0];




		if (!changedTextOfThisQuestion) {
			changedTextOfThisQuestion = true;
			if (DoesHeroKnowAnswer ()) {
				Debug.Log ("zna");

				Debug.Log ("poprawna odpowiedx = " + correctAnswersArray[currentQuestionNumber-1]);

				Debug.Log ("poprawna odpowiedx = " + correctAnswersArray[1]);

				knowAnswerText.text = "Postać zna odpowiedź, jest nią odpowiedź: " + correctAnswersArray[currentQuestionNumber-1];
				moveButton.interactable = true;

			} else {
				Debug.Log ("nie zna");
				knowAnswerText.text = "Postać nie zna odpowiedzi";
				shootButton.interactable = true;
				cheatButton.interactable = true;
			}
		}

		
	}


	private bool DoesHeroKnowAnswer(){ 		// wiedza max 10 pkt * 5

		float points = Stats.Knowledge * 5 + Random.Range (0f, 50f);

		Debug.Log ("points " + points);


		if (points > 60) {
			correctAnswers++;
			return true;
		} else {
			return false;
		}
	}

	private bool DoesCheatSucced(){ // cheat max 10 pkt * 5

		float points = Stats.Cheating * 5 + Random.Range (0f, 50f);

		Debug.Log ("points " + points);

		if (points > 60) {
			correctAnswers++;
			return true;
		} else {
			return false;
		}
	}

	private bool DoesShootSucced(){ //  4 odpowiedzi = 25%

		float points = Random.Range (0f, 100f);

		Debug.Log ("points " + points);

		if (points > 60) {
			correctAnswers++;
			textComponents [4].text = "Udało Ci się trafić we właściwą odpowiedź! Poprawna odpowiedź to : " + correctAnswersArray[currentQuestionNumber-1];
			return true;
		} else {
			textComponents [4].text = "Nie udało Ci się trafić we właściwą odpowiedź! Poprawna odpowiedź to : " + correctAnswersArray[currentQuestionNumber-1];
			return false;
		}
	}

	public void ChangeQuestion(){


		Debug.Log ("teraz pytanie numer = " + currentQuestionNumber);
		++currentQuestionNumber;

		Debug.Log ("teraz pytanie numer = " + currentQuestionNumber);
		shootButton.interactable = false;
		cheatButton.interactable = false;
		moveButton.interactable = false;

		Debug.Log ("current question NUmber = " + currentQuestionNumber);

		// tu dać text z nastepnego pytania
		if (currentQuestionNumber > questionsNumber) {
			
			if (correctAnswers == 1) {
				if (questionsNumber / 2 <= correctAnswers) {
					textComponents [0].text = "koniec egzaminu. Postać odpowiedziała poprawnie: " + correctAnswers + " raz. Na " +
						questionsNumber + " pytań. Postać zdała egzamin. Koniec gry, udaj się do menu, aby zagrać ponownie.";
				} else {
					
					textComponents [0].text = "koniec egzaminu. Postać odpowiedziała poprawnie: " + correctAnswers + " raz. Na " +
						questionsNumber + " pytań. Postać nie zdała egzaminu. Koniec gry, udaj się do menu, aby zagrać ponownie.";
				}
			} else {
				if (questionsNumber / 2 <= correctAnswers) {
					textComponents [0].text = "koniec egzaminu. Postać odpowiedziała poprawnie: " + correctAnswers + " razy. Na " +
						questionsNumber + " pytań. Postać zdała egzamin. Koniec gry, udaj się do menu, aby zagrać ponownie.";
				} else {

					textComponents [0].text = "koniec egzaminu. Postać odpowiedziała poprawnie: " + correctAnswers + " razy. Na " +
						questionsNumber + " pytań. Postać nie zdała egzaminu. Koniec gry, udaj się do menu, aby zagrać ponownie.";
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

			textComponents [0].text = ChangeQuestionText (currentQuestionNumber);
		}


		Debug.Log ("teraz pytanie numer = " + currentQuestionNumber);

	}

	public void Cheat(){

		shootButton.interactable = false;
		cheatButton.interactable = false;
		moveButton.interactable = false;

		bool cheatSucced = DoesCheatSucced ();

		Debug.Log ("cheat udało się " + cheatSucced);

		if (!cheatSucced) {

			textComponents [0].text = "Postać została przyłapana na ściąganiu. Nie zdała egzaminu.";

			goBackToMenuButton.gameObject.SetActive (true);

		} else {
			Debug.Log (" correctAnswersArray[currentQuestionNumber-1] " +  correctAnswersArray[currentQuestionNumber-1]);
			Debug.Log ("currentQuestionNumber " +  currentQuestionNumber);
			Debug.Log (" correctAnswersArray[2] " +  correctAnswersArray[2]);
			textComponents [4].text = "Udało Ci się sciągnąć! Zaznaczyłeś odpowiedź: " + correctAnswersArray[currentQuestionNumber-1];
			moveButton.interactable = true;
		}
	

		Debug.Log ("teraz pytanie numer = " + currentQuestionNumber);

	}


	public void Shoot(){

		shootButton.interactable = false;
		cheatButton.interactable = false;

		bool shootSucced = DoesShootSucced ();


		Debug.Log ("Strzał się udał? " + shootSucced);

		moveButton.interactable = true;


	}


	public void GoToMenu(){

		Application.LoadLevel ("Menu");

	}

	public string ChangeQuestionText(int currentQuestionNumber){

		if (currentQuestionNumber == 2) {
			// final public class Test {}, czyli b
			return @"
	2.	
	Która opcja jest poprawną deklaracją dla niezagnieżdżonych klas lub interfejsów?
		a) final abstract class Test {}
		b) final public class Test {}
		c) protected abstract class Test {}
		d) protected interface Test {}";

		} else if (currentQuestionNumber == 3) {
			return @"
		3. Jakie będzie wyjście programu?
			public class Test 
			{ 
				private static float[] f = new float[2]; 
				public static void main (String[] args) 
				{
					System.out.println('f[0] = ' + f[0]); 
				} 
			}

			a).	f[0] = 0
			b).	f[0] = 0.0
			c).	 Compile Error
			d).	Runtime Exception";

		}
		else{

			return "błąd brak pytania.";
		}
	}


}
