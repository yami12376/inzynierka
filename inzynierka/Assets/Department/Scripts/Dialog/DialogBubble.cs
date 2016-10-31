using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using AssemblyCSharp;


public class DialogBubble : MonoBehaviour
{
	Ray ray;
	RaycastHit hit;

	public GameObject currentBubble = null;
	public float timeToCloseBubble;
	public List<PixelBubble> bubblesList = new List<PixelBubble> ();
	private PixelBubble activeBubble = null;

	public GameObject prefab;
	public GameObject prefab2;


	private GameObject InstantiateBubble (PixelBubble bubblesList, DialogBubble dialogBubble)
	{
		GameObject newBubbleDialogObject = null;

		//create a rectangle or round bubble
		if (bubblesList.messageForm == BubbleType.Rectangle) {
			newBubbleDialogObject = (GameObject)Instantiate (prefab, dialogBubble.transform.position + new Vector3 (4f, 4.25f, 0f)
				, Quaternion.identity);
		} else {
			newBubbleDialogObject = (GameObject)Instantiate (prefab2, dialogBubble.transform.position + new Vector3 (0.25f, 4.5f, 0f)
				, Quaternion.identity);
		}

		return newBubbleDialogObject;
	}

	private void RenderBodyOfBubble (GameObject pixelBubbleObject, PixelBubble pixelBubble, string trueMessage)
	{
		Color newBodyColor = new Color (pixelBubble.bodyColor.r, pixelBubble.bodyColor.g, pixelBubble.bodyColor.b, 255f);
		Color newBorderColor = new Color (pixelBubble.borderColor.r, pixelBubble.borderColor.g, pixelBubble.borderColor.b, 255f);
		Color newFontColor = new Color (pixelBubble.fontColor.r, pixelBubble.fontColor.g, pixelBubble.fontColor.b, 255f);

		//get all image below the main Object
		foreach (Transform child in pixelBubbleObject.transform) {
			SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer> ();
			TextMesh textMesh = child.GetComponent<TextMesh> ();

			if (spriteRenderer != null && child.name.Contains ("Body")) {
				spriteRenderer.color = newBodyColor; //change the body color

			} else if (spriteRenderer != null && child.name.Contains ("Border")) {
				spriteRenderer.color = newBorderColor; 	//change the border color

			} else if (textMesh != null && child.name.Contains ("Message")) {
				//change the message and show it in front of everything
				textMesh.color = newFontColor;
				textMesh.text = trueMessage;

				Transform mouseIcon = child.FindChild ("MouseIcon");
				if (mouseIcon != null && !pixelBubble.clickToCloseBubble) {
					mouseIcon.gameObject.SetActive (false);
				}
			}

			//disable the mouse icon because it will close by itself
			if (child.name == "MouseIcon" && !pixelBubble.clickToCloseBubble) {
				child.gameObject.SetActive (false);
			} else {
				activeBubble = pixelBubble; //keep the active bubble and wait for the Left Click
			}
		}
	}

	public string ModifyTextFromComponentByAddindNewLineAfterWords(PixelBubble pixelBubble)
	{
		//cut the message into 24 characters
		string trueMessage = "";
		string line = "";
		int limit = 20;
		if (pixelBubble.messageForm == BubbleType.Round) {
			limit = 15;
		}

		//cut each word in a text in 24 characters.
		foreach (string word in pixelBubble.message.Split(' ')) {
			if (line.Length + word.Length > limit) {
				trueMessage += line + System.Environment.NewLine;  

				line = ""; //add a line break after   //then reset the current line
			}
			line += word + " "; 	//add the current word with a space
		}
		trueMessage += line; //add the last line

		return trueMessage;
	}



	//show the right bubble on the current character
	void ShowBubble (DialogBubble dialogBubble)
	{
		//if vcurrentbubble is still there, just close it
		if (activeBubble != null) {
			if (activeBubble.clickToCloseBubble) {
				if (dialogBubble.currentBubble != null) { //get the function to close bubble
					Appear appear = dialogBubble.currentBubble.GetComponent<Appear> ();
					appear.closeBubble = true; //close bubble
				}
			}
		}

		foreach (PixelBubble pixelBubble in dialogBubble.bubblesList) {
			if (dialogBubble.currentBubble == null) { //make sure the bubble isn't already opened

				string trueMessage = ModifyTextFromComponentByAddindNewLineAfterWords (pixelBubble);

				GameObject bubblesListObject = InstantiateBubble (pixelBubble, dialogBubble);

				//show the mouse and wait for the user to left click OR NOT (if not, after X sec, it disappear)
				bubblesListObject.GetComponent<Appear> ().needToClick = pixelBubble.clickToCloseBubble;

				RenderBodyOfBubble (bubblesListObject, pixelBubble, trueMessage);

				dialogBubble.currentBubble = bubblesListObject; //attach it to the player
				bubblesListObject.transform.parent = dialogBubble.transform; //make him his parent
			} else if (activeBubble == pixelBubble && activeBubble.clickToCloseBubble) {
				//gotonextbubble = true;
				dialogBubble.currentBubble = null;
			}
		}
	}


	void Update ()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (ray.origin, ray.direction, 2);


		if (hit.collider != null && Input.GetMouseButtonDown (0)) {

			if (this.transform.childCount == 1) { // odwołujemy się do NPC, który ma już włączoną chmurkę

				if (hit.transform == this.transform
					|| hit.transform == this.transform.GetChild (0).transform) { // spr. czy klikamy na postać czy jego chmurkę 
					// czy skoro jest już ta chmurka to kliknelismy w chmurke czy gracza:
					// hierarchia dziedziczenia: NPCs->NPCx->Chmurka
					if (hit.transform.parent.tag != "NPC") { // ale nie odwołuj się do parenta wszystkich NPC.
						ShowBubble (hit.transform.parent.GetComponent<DialogBubble> ()); // mozna bezpiecznie odwolac sie do ojca, bo to 
						// chmurka
					} else {
						ShowBubble (hit.transform.GetComponent<DialogBubble> ());
					}
				}
			} else { // odwołujemy się do NPC, który nie ma aktywnej chmurki 

				int currentBubblesCount = (GameObject.FindGameObjectsWithTag ("Bubble")).Length;

				if (hit.transform == this.transform && currentBubblesCount < 1) { // to spr. którego klikamy + czy nigdzie indziej nie ma aktywnej
					// chmurki  // && y < 1  -> z 1 osobą rozmawiać na raz można
					if (bubblesList.Count > 0) { // jezeli trzeba pokazac wiecej niz 0 chmurek, to je pokaz.
						ShowBubble (hit.transform.GetComponent<DialogBubble> ());
					}
				}
			}
		}
	}
}
