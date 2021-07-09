using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : ObjectController
{
	public delegate void PickableController(AssetItem item);
	public static event PickableController clickOnObject;
	[SerializeField] private AssetItem item;
	[SerializeField] private LayerMask whatIsPlayer;
	[SerializeField] private float checkRadius = 1f;
	private bool isPlayer = false;

	void OnMouseDown()
	{
		if (canBeClicked) 
		{
			isPlayer = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
			if (isPlayer)
			{
				material.shader = Shader.Find("Sprites/Default");
				Destroy(this.GetComponent<PickableObject>());
				if (clickOnObject != null) clickOnObject.Invoke(item);
			}
		}
	}
}
