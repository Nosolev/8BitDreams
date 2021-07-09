using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
 {
	 [SerializeField] private float speed;
	 [SerializeField] private float fireRate;
	 [SerializeField] private Transform shootSpawn;
	 [SerializeField] private GameObject buletReference;
	 [SerializeField] private float buletForce;
	 private Rigidbody2D enemyBody;
	 private float nextFire;
	void Start () 
	{
		enemyBody = GetComponent<Rigidbody2D>();
		enemyBody.velocity = new Vector2(enemyBody.velocity.x, speed * -1);
	}
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
}
