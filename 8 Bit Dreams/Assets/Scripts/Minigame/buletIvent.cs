using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buletIvent : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Enemy")
		{
			Destroy(collider.gameObject);
			Destroy(gameObject);
		}
	}
}
