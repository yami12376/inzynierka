using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;


public class Appear : MonoBehaviour
{

	private List<SpriteRenderer> vImages;
	public bool dontCloseBubble = true;
	public bool needToClick = false;

	void Start ()
	{

		vImages = new List<SpriteRenderer> ();

		//get all image below the main Object
		foreach (Transform child in transform) {
			SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer> ();
			if (spriteRenderer != null)
				vImages.Add (spriteRenderer);
		}
	}

	IEnumerator WaitInSeconds (float time, string choice)
	{
		yield return new WaitForSeconds (time);
		switch (choice) {
		case "False":
			dontCloseBubble = false;
			break;
		}
	}

	//make the alpha appear
	public void ImageAppear ()
	{
		foreach (SpriteRenderer spriteRenderer in vImages)
			spriteRenderer.color = new Color (spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 200f);
		// ostatni parametr vAlpha
	}

	// Update is called once per frame
	void Update ()
	{
		DialogBubble dialogBubbleScriptComponent = transform.parent.GetComponent<DialogBubble> ();
		Debug.Log (dontCloseBubble + " : dontClose");
		if (dontCloseBubble) {
			ImageAppear ();
		} else if (!dontCloseBubble) {
			//before deleting himself, we tell the character this buble is no more
			foreach (PixelBubble bubble in transform.parent.GetComponent<DialogBubble>().bubblesList)
				if (dialogBubbleScriptComponent.vCurrentBubble == this.gameObject && !bubble.vClickToCloseBubble) { //remove current bubble ONLY if it must dissappear by itself
					dialogBubbleScriptComponent.vCurrentBubble = null; //remove it
				}

			//destroy itself
			GameObject.Destroy (this.gameObject); 
		}
		if (!needToClick) {
			StartCoroutine (WaitInSeconds (dialogBubbleScriptComponent.timeToCloseBubble, "False"));
		}
	}
}
