using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSender : ObjectController
{
	public delegate void Sender(string value, float time);
	public static event Sender sender;

	[SerializeField] private string send;
	[SerializeField] private float showTime;
	[SerializeField] private float checkRadius = 1f;
	[SerializeField] private LayerMask whatIsPlayer;
	private bool isPlayer = false;

	void OnMouseDown()
	{
		if (canBeClicked)
		{
			isPlayer = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
			if (isPlayer)
			{
				if (sender != null) sender.Invoke(send, showTime);
			}
		}
	}
}
