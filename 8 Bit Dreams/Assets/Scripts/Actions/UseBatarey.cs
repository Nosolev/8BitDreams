using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBatarey : MonoBehaviour 
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
			Destroy(target.gameObject);
		}
	}
}
