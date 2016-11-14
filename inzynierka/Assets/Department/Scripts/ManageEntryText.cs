using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class ManageEntryText : MonoBehaviour
{

	public float time = 20;

	// Use this for initialization
	void Start ()
	{
		InvokeRepeating ("ChangeText", 1f, 1f);
	}

	void ChangeText ()
	{
		if (time == 0) {
			Application.LoadLevel ("Menu");
		}
		
		Text text = this.GetComponent<Text> ();

		text.text = "Masz 20 sekund żeby zdążyć na egzamin z analizy matematycznej! Śpiesz się!! Udaj się do sali numer 2005. Pozostały czas = " + time;
		time--;
	}
}
