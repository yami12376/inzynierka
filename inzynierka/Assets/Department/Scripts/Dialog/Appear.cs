using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;


public class Appear : MonoBehaviour {

	private List<SpriteRenderer> vImages;
	public float valpha = 0f;
	public bool vchoice = true;
	public bool needToClick = false;

	void Start () {

		vImages = new List<SpriteRenderer> ();

		//get all image below the main Object
		foreach (Transform child in transform)
		{
			SpriteRenderer vRenderer = child.GetComponent<SpriteRenderer> ();
			if (vRenderer != null)
				vImages.Add (vRenderer);
		}
	}

	IEnumerator WaitInSeconds(float vseconds, string vChoice) {
		yield return new WaitForSeconds(vseconds);
		switch (vChoice) {
		case "False":
			vchoice = false;
			break;
		}
	}

	//make the alpha appear
	public void ImageAppear()
	{
		foreach (SpriteRenderer vRenderer in vImages)
			vRenderer.color = new Color (vRenderer.color.r, vRenderer.color.g, vRenderer.color.b, valpha);

		if (vchoice)
			valpha+=5f;
		else 
			valpha-=5f;
	}

	// Update is called once per frame
	void Update () {
		DialogBubble dialogBubbleScriptComponent = transform.parent.GetComponent<DialogBubble> ();
		if ((vchoice && valpha < 255) || (!vchoice && valpha > 0)) {
			ImageAppear ();


		}
		else if (!vchoice && valpha<= 0)
		{
			

			//before deleting himself, we tell the character this buble is no more
			foreach (PixelBubble bubble in transform.parent.GetComponent<DialogBubble>().bubblesList)
				if (dialogBubbleScriptComponent.vCurrentBubble == this.gameObject && !bubble.vClickToCloseBubble) //remove current bubble ONLY if it must dissappear by itself
				{
					dialogBubbleScriptComponent.vCurrentBubble = null; //remove it
					dialogBubbleScriptComponent.IsTalking = false;
				}

			//destroy itself
			GameObject.Destroy (this.gameObject); 
		}
		else if ((valpha == 255f) &&(!needToClick))
		{
			valpha = 254f;
			StartCoroutine(WaitInSeconds(dialogBubbleScriptComponent.timeToCloseBubble, "False"));
		}
	}		
}
