using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprintControl : MonoBehaviour {

	public float topSpeed = 10f;
	private Rigidbody2D rg2d;
	//private bool facingRight = true;

	private Animator anim;

	private bool ground = false;
	public Transform groundCheck;
	private float groundRadius = 0.2f;
	public LayerMask grounded;

	public float jumpPower = 700f;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		rg2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		ground = Physics2D.OverlapCircle (groundCheck.position, groundRadius, grounded);

		anim.SetBool ("Ground", ground);

		anim.SetFloat ("vSpeed",rg2d.velocity.y);

		rg2d.velocity = new Vector2 (topSpeed,rg2d.velocity.y);
		anim.SetFloat ("Speed", rg2d.velocity.x);
		if (ground && Input.GetKeyDown (KeyCode.Space))
		{
			anim.SetBool ("Ground", false);
			rg2d.AddForce (new Vector2(0,jumpPower));
		}
	}
	/* Used for full control of directions
	void FixedUpdate()
	{
		ground = Physics2D.OverlapCircle (groundCheck.position, groundRadius, grounded);

		anim.SetBool ("Ground", ground);

		anim.SetFloat ("vSpeed",rg2d.velocity.y);

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", Mathf.Abs(move));
		rg2d.velocity = new Vector2 (move * topSpeed,rg2d.velocity.y);
		if (move > 0 && !facingRight) 
		{
			Flip ();
		}
		else if(move<0 && facingRight)
		{
			Flip();
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
}
