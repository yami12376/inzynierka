using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayCheating : MonoBehaviour {

	private Text textComponent;
	int cheating = Stats.Cheating;

	void Start()
	{
		textComponent = GetComponent<Text>();
		textComponent.text = cheating.ToString();
	}

	void Update()
	{
		cheating = Stats.Cheating;
		textComponent.text = cheating.ToString();
	}
}
