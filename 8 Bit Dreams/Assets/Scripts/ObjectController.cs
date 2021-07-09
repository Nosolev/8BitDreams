using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
	public bool canBeClicked = true;

	[SerializeField]
	private float outlineWidth = 0.1f;
	public Material material;

	void Start()
	{
		material = GetComponent<SpriteRenderer>().material;
	}

	void OnMouseOver()
	{
		if (canBeClicked) material.SetFloat("_OutlineWidth", outlineWidth);
	}

	void OnMouseExit()
	{
		material.SetFloat("_OutlineWidth", 0);
	}

	bool ObjectConditionController()
	{
		canBeClicked = !canBeClicked;
		return canBeClicked;
	}

	void OnEnable()
	{
		ViewObject.clickOnObject += ObjectConditionController;
		OnViewObject.clickOnObject += ObjectConditionController;
	}

	void OnDisable()
	{
		ViewObject.clickOnObject -= ObjectConditionController;
		OnViewObject.clickOnObject -= ObjectConditionController;
	}
}
