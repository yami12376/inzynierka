using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class GameStart : MonoBehaviour
{
	private Text[] classNumbers;
	private System.Random rnd = new System.Random ();

	void Start ()
	{

		var randomNumbers = Enumerable.Range (1, 9).OrderBy (x => rnd.Next ()).Take (9).ToList ();
	
		classNumbers = GameObject.FindGameObjectWithTag("Canvases").GetComponentsInChildren<Text>();

		int i = 0;

		foreach (Text classNumber in classNumbers) {
			classNumber.text = "sala200" + randomNumbers.ElementAt (i);
			i++;
		}
	}
}
