using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayRemaining : MonoBehaviour
{


	private Text textComponent;
	int points = Stats.Remaining;

	void Start ()
	{
		textComponent = GetComponent<Text> ();
		textComponent.text = points.ToString ();
	}

	void Update ()
	{
		points = Stats.Remaining;
		textComponent.text = points.ToString ();
	}
}
