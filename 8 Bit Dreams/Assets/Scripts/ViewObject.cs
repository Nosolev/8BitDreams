using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewObject : ObjectController 
{
	public delegate bool ConditionController();
	public static event ConditionController clickOnObject;

	[SerializeField]
	private GameObject referenceObject;
	[SerializeField]
	private float checkRadius = 1f;
	[SerializeField]
	private LayerMask whatIsPlayer;
	private bool isPlayer = false;

	void OnMouseDown()
	{
		if (canBeClicked) 
		{
			isPlayer = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
			if (isPlayer)
			{
				Instantiate(referenceObject);
				if (clickOnObject != null) clickOnObject.Invoke();
			}
		}
	}
}
