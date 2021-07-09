using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour 
{
	private Text diaolog;

	void Start () 
	{
		diaolog = GetComponent<Text>();
		Clear();
	}

	void Clear()
	{
		diaolog.text = "";
	}
	
	void OutputSingle (string value, float time)
	{
		if (diaolog.text == "")
		{
			diaolog.text = value;
			Invoke("Clear", time);
		}
	}

	void OnEnable()
	{
		DialogSender.sender += OutputSingle;
	}

	void OnDisable()
	{
		DialogSender.sender -= OutputSingle;
	}
}
