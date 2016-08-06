using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayKnowledge : MonoBehaviour {

	private Text textComponent;
	int wisdom = Stats.Knowledge;

	void Start () {
		textComponent = GetComponent<Text>();
		textComponent.text = wisdom.ToString();
	}

	void Update () {
		wisdom = Stats.Knowledge;
		textComponent.text = wisdom.ToString();
	}
}

