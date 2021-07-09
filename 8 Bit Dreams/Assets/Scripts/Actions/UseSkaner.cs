using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkaner : MonoBehaviour 
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
			target.gameObject.GetComponent<ObjectController>().canBeClicked = true;
		}
	}
}
