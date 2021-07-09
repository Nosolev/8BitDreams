using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnViewObject : MonoBehaviour 
{
	public delegate bool ConditionController();
	public static event ConditionController clickOnObject;

	void OnMouseDown()
	{
		if (clickOnObject != null) clickOnObject.Invoke();
		Destroy(gameObject);
	}
}
