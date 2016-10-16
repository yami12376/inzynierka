using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class GameStart : MonoBehaviour
{
	private GameObject[] classNumbers;
	private System.Random rnd = new System.Random ();

	void Start ()
	{

		var randomNumbers = Enumerable.Range (1, 9).OrderBy (x => rnd.Next ()).Take (9).ToList ();
	
		classNumbers = GameObject.FindGameObjectsWithTag ("Class Number");

		int i = 0;

		foreach (GameObject classNumber in classNumbers) {
			classNumber.GetComponentInChildren<Text> ().text = "sala200" + randomNumbers.ElementAt (i);
			Debug.Log (randomNumbers.ElementAt (i));
			i++;
		}
	}
}
