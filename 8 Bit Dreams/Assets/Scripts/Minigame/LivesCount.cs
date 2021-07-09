using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesCount : MonoBehaviour 
{
	static public int lives = 3;
	[SerializeField] private Image[] livesUI;
	void Start()
	{
		for (int i = 0; i < livesUI.Length; i++)
		{
			if (i < lives) livesUI[i].enabled = true;
			else livesUI[i].enabled = false;
		}
	}
}
