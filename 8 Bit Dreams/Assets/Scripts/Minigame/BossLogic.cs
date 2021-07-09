using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour 
{
	public delegate void NextLvl();
	public static event NextLvl senderLvl;
	[SerializeField] private int gunsCount = 2;
	void Start()
	{

	}
	void OnEnable()
	{
		GunsLogic.sender += GunsDisable;
	}

	void OnDisable()
	{
		senderLvl.Invoke();
		GunsLogic.sender -= GunsDisable;
	}
	void GunsDisable()
	{
		if (gunsCount > 1)
		{
			gunsCount -= 1;
		}
		else if(gunsCount == 1)
		{
			this.GetComponent<BoxCollider2D>().enabled = true;
		}
	}
}
