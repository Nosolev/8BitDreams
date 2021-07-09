using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseBridge : MonoBehaviour 
{
	[SerializeField] private GameObject target;
	private ObjectController OnClick;
	void Start()
	{
		OnClick = this.GetComponent<ObjectController>();
	}

	void OnMouseDown()
	{
		if (OnClick.canBeClicked)
		{
			SceneManager.LoadScene("TheEnd");
		}
	}
}
