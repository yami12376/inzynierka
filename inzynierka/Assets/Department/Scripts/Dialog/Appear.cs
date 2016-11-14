using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class Appear : MonoBehaviour
{
	public bool closeBubble = false;
	public bool needToClick = false;

	IEnumerator CloseBubblesAfterSeconds (float time)
	{
		yield return new WaitForSeconds (time);
		closeBubble = true;
	}

	void Update ()  // Update is called once per frame
	{
		DialogBubble dialogBubbleScriptComponent = transform.parent.GetComponent<DialogBubble> ();
		if (closeBubble) {
			//before deleting himself, we tell the character this buble is no more
			foreach (PixelBubble bubble in transform.parent.GetComponent<DialogBubble>().bubblesList) {
				if (dialogBubbleScriptComponent.currentBubble == this.gameObject && !bubble.clickToCloseBubble) { 
					//remove current bubble ONLY if it must dissappear by itself
					dialogBubbleScriptComponent.currentBubble = null; //remove it
				}
			}
			//destroy itself
			GameObject.Destroy (this.gameObject); 
		}
		if (!needToClick) {
			StartCoroutine (CloseBubblesAfterSeconds (dialogBubbleScriptComponent.timeToCloseBubble));
		}
	}
}
