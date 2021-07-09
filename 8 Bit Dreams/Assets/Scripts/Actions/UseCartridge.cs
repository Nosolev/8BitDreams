using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseCartridge : MonoBehaviour 
{
	private ObjectController OnClick;
	void Start()
	{
		OnClick = this.GetComponent<ObjectController>();
	}

	void OnMouseDown()
	{
		if (OnClick.canBeClicked)
		{
			SceneManager.LoadScene("SpaceGame");
		}
	}
}
