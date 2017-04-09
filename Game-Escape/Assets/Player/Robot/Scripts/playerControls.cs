using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerControls : MonoBehaviour {

	public float speed = 10f;
	private Rigidbody2D rg2d;
	private bool facingRight = true;

	public float speedMultiplier;
	public float speedTarget;
	private float speedTargetCounter;

	private Animator anim;

	private bool ground = false;
	public Transform groundCheck;
	private float groundRadius = 0.1f;
	public LayerMask grounded;

	public float jumpPower = 10f;
	public float jumpTime;
	private float jumpTimer;
	private bool endJump;
	private bool canDoubleJump;

	public GameObject DeathMenu;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rg2d = GetComponent<Rigidbody2D> ();
		rg2d.isKinematic = false;
		jumpTimer = jumpTime;
		speedTargetCounter = speedTarget;
		endJump = true;
		canDoubleJump = true;
	}

	// Update is called once per frame
	void Update () {

		ground = Physics2D.OverlapCircle (groundCheck.position, groundRadius, grounded);
		anim.SetFloat ("vSpeed",rg2d.velocity.y);
		anim.SetBool ("Ground", ground);
		anim.SetFloat ("Speed", rg2d.velocity.x);
		if (transform.position.x > speedTargetCounter) 
		{
			speed = speed*speedMultiplier;
			speedTarget = speedTarget * speedMultiplier;
			speedTargetCounter += speedTarget;

		}

		rg2d.velocity = new Vector2 (speed,rg2d.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (ground) 
			{
				anim.SetBool ("Ground", false);
				rg2d.velocity = new Vector2 (rg2d.velocity.x, jumpPower);
				//rg2d.AddForce (new Vector2(0,jumpPower));
				endJump = false;
			}
			if (!ground && canDoubleJump) 
			{
				anim.SetBool ("Ground", false);
				rg2d.velocity = new Vector2 (rg2d.velocity.x, jumpPower);
				//rg2d.AddForce (new Vector2(0,jumpPower));
				jumpTimer = jumpTime;
				endJump = false;
				canDoubleJump = false;
			}
		}
		if (jumpTimer>0 && Input.GetKey (KeyCode.Space) && !endJump)
		{
			rg2d.velocity = new Vector2 (rg2d.velocity.x,jumpPower);
			//rg2d.AddForce (new Vector2(0,jumpPower));
			jumpTimer -= Time.deltaTime;

		}
		if (Input.GetKeyUp (KeyCode.Space))
		{
			jumpTimer = 0;
			endJump = true;
		}
		if (ground) 
		{
			jumpTimer = jumpTime;
			canDoubleJump = true;
		}


	}
	/*
	//Full Control
	void FixedUpdate()
	{
		ground = Physics2D.OverlapCircle (groundCheck.position, groundRadius, grounded);

		anim.SetBool ("Ground", ground);

		anim.SetFloat ("vSpeed",rg2d.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs(move));
		rg2d.velocity = new Vector2 (move * speed,rg2d.velocity.y);
		if (move > 0 && !facingRight) 
		{
			Flip ();
		}
		else if(move<0 && facingRight)
		{
			Flip();
		}
		if (ground && Input.GetKeyDown (KeyCode.Space))
		{
			anim.SetBool ("Ground", false);
			rg2d.velocity = new Vector2 (rg2d.velocity.x,jumpPower);
			//rg2d.AddForce (new Vector2(0,jumpPower));
		}
		if (jumpTimer>0 && Input.GetKey (KeyCode.Space))
		{
			rg2d.velocity = new Vector2 (rg2d.velocity.x,jumpPower);
			//rg2d.AddForce (new Vector2(0,jumpPower));
			jumpTimer -= Time.deltaTime;
		}
		if (Input.GetKeyUp (KeyCode.Space))
		{
			jumpTimer = 0;
		}
		if (ground) 
		{
			jumpTimer = jumpTime;
		}
	}
		
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
	*/

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Death") 
		{
			DeathMenu.SetActive (true);
			gameObject.SetActive (false);
			GameObject.Find ("ScoreManager").SetActive (false);
		}
	}
}
