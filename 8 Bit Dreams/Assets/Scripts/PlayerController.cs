using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	private float speed = 5f;
	private float horizontalSpeed;
	private Animator animator;
	private SpriteRenderer spriteRenderer;
	private Rigidbody2D rigidBody;
	private bool canMove = true;

	void Start () 
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () 
	{
		if (canMove) MovementLogic();
		else animator.SetFloat("Speed", 0);
	}

	void MovementLogic()
	{
		horizontalSpeed = Input.GetAxis("Horizontal");
		animator.SetFloat("Speed", Mathf.Abs(horizontalSpeed));
		if (horizontalSpeed > 0) spriteRenderer.flipX = false;
		else if (horizontalSpeed < 0) spriteRenderer.flipX = true;
		rigidBody.velocity = new Vector2(speed * horizontalSpeed, rigidBody.velocity.y);
	}

	bool PlayerConditionController()
	{
		canMove = !canMove;
		return canMove;
	}

	void OnEnable()
	{
		ViewObject.clickOnObject += PlayerConditionController;
		OnViewObject.clickOnObject += PlayerConditionController;
	}

	void OnDisable()
	{
		ViewObject.clickOnObject -= PlayerConditionController;
		OnViewObject.clickOnObject += PlayerConditionController;
	}
}
