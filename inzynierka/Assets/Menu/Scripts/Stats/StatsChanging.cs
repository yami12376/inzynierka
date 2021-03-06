﻿using UnityEngine;
using System.Collections;

public class StatsChanging : MonoBehaviour
{

	public string levelToLoad;

	void Start ()
	{
		Stats.Cheating = 0;
		Stats.Knowledge = 0;
		Stats.Remaining = 15;
		Stats.StartCheating = 0;
		Stats.StartKnowledge = 0;
	}

	public void KnowledgeUp ()
	{
		if (Stats.Remaining > 0 && Stats.Knowledge < Stats.Max) {
			Stats.Remaining -= 1;
			Stats.Knowledge += 1;
		}

	}

	public void KnowledgeDown ()
	{
		if (Stats.Remaining < Stats.Points && Stats.Knowledge > Stats.StartKnowledge) {
			Stats.Remaining += 1;
			Stats.Knowledge -= 1;
		}
	}

	public void CheatingUp ()
	{
		if (Stats.Remaining > 0 && Stats.Cheating < Stats.Max) {
			Stats.Remaining -= 1;
			Stats.Cheating += 1;
		}
	}

	public void CheatingDown ()
	{
		if (Stats.Remaining < Stats.Points && Stats.Cheating > Stats.StartCheating) {
			Stats.Remaining += 1;
			Stats.Cheating -= 1;
		}
	}

	public void Submit ()
	{

		Stats.StartCheating = Stats.Cheating;
		Stats.StartKnowledge = Stats.Knowledge;

		Application.LoadLevel (levelToLoad);
	}
}

