using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsLogic : MonoBehaviour 
{
	public delegate void Sender();
	public static event Sender sender;
	[SerializeField] private float fireRate;
	[SerializeField] private Transform shootSpawn;
	[SerializeField] private GameObject buletReference;
	[SerializeField] private float buletForce;
	private float nextFire;

	 void FixedUpdate()
	{
		ShootLogic();
	}
	void ShootLogic()
	{
		if(Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			var bulet = Instantiate(buletReference, shootSpawn.position, shootSpawn.rotation);
			bulet.GetComponent<Rigidbody2D>().AddForce(Vector2.down * buletForce * Time.deltaTime);
		}
	}
	void OnDisable()
	{
		if (sender != null) sender.Invoke();
	}
}
