using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public void LoadScene (string level)
	{
		LastScene.myLastScene = Application.loadedLevelName;
		Application.LoadLevel (level);
	}

	public void Exit ()
	{

		Application.Quit ();
	}
}
