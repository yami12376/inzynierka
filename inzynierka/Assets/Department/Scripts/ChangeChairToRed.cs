using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class ChangeChairToRed : MonoBehaviour {

	public Sprite chairRed;
	private bool instantiated;

	// Update is called once per frame
	void Update () {

		int currentBubblesCount = (GameObject.FindGameObjectsWithTag ("Bubble")).Length;

		if (currentBubblesCount > 0) {


			GameObject classThatIsearchForGameObject = GameObject.FindGameObjectWithTag ("Class That I Search For");

			string classThatISearchForTag = classThatIsearchForGameObject.transform.parent.tag;

			Debug.Log ("tag: " + classThatISearchForTag);


			if (classThatISearchForTag != null && !instantiated) {
				instantiated = true;

				string sub = GetTextBetween (classThatISearchForTag, "class", "number");
				Debug.Log ("sub = " + sub);

				GameObject chairToChangeGraphic = GameObject.FindGameObjectWithTag ("Class " + sub + " Chair To Change");
				Debug.Log ("ch= " + chairToChangeGraphic);
				chairToChangeGraphic.GetComponent <SpriteRenderer> ().sprite = chairRed;
				chairToChangeGraphic.AddComponent<BoxCollider2D> ().isTrigger = true;

			}
		}
	
	}

	public static string GetTextBetween(string source, string leftWord, string rightWord)
	{
		return
			Regex.Match(source, string.Format(@"{0}\s(?<words>[\w\s]+)\s{1}", leftWord, rightWord),
				RegexOptions.IgnoreCase).Groups["words"].Value;
	}
}
