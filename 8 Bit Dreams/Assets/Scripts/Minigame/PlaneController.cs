using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneController : MonoBehaviour 
{
	[SerializeField] private float speed;
	[SerializeField] private GameObject buletReference;
	[SerializeField] private float fireRate;
	[SerializeField] private Transform shootSpawn;
	[SerializeField] private float buletForce;
	private float horizontalSpeed;
	private Rigidbody2D rb;
	private float nextFire;
	void OnEnable() 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate () 
	{
		MovementLogic();
		ShootLogic();
	}
	void MovementLogic()
	{
		horizontalSpeed = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(speed * horizontalSpeed, rb.velocity.y);
	}
	void ShootLogic()
	{
		if(Input.GetAxis("Fire1") > 0 && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			var bulet = Instantiate(buletReference, shootSpawn.position, shootSpawn.rotation);
			bulet.GetComponent<Rigidbody2D>().AddForce(Vector2.up * buletForce * Time.deltaTime);
		}
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Enemy")
		{
			if(LivesCount.lives > 1)
			{
				LivesCount.lives -= 1;
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
			else if (LivesCount.lives == 1)
			{
				LivesCount.lives = 3;
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}
		}
	}
}
