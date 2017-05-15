using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : Observable {

	private bool shielded = false;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = Character.GetSprite ();
		gameObject.GetComponent<Animator>().runtimeAnimatorController = Character.GetAnim ();
	}

	// Update is called once per frame
	void Update () 
	{

		gameObject.GetComponent<Animator> ().SetFloat ("vSpeed",gameObject.GetComponent<Rigidbody2D>().velocity.y);

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0))
		{

			Notify (gameObject, "Jump");
		}
		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0))
		{
			Notify (gameObject, "Longer Jump");

		}
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0))
		{
			Notify (gameObject, "End Jump");

		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Death") 
		{
			Notify (gameObject, "Death");
		}
		if (other.gameObject.tag == "Danger") 
		{
			if(!shielded)Notify (gameObject, "Death");
			if (shielded) {
				Notify (gameObject, "Protected", other.gameObject);
				shielded = false;
			}
		}
		if (other.gameObject.tag == "Coin") 
		{
			Notify (other.gameObject, "CoinCollection");
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.tag == "DoubleUp") 
		{
			Notify (other.gameObject, "DoubleUp");
			other.gameObject.SetActive (false);
		}
		if (other.gameObject.tag == "ShieldUp") 
		{
			shielded = true;
			Notify (other.gameObject, "ShieldUp",gameObject);
		}
		if (other.gameObject.tag == "SlowDown") 
		{
			if(!shielded)Notify (other.gameObject, "SlowDown");
			if (shielded) {
				Notify (gameObject, "Protected", other.gameObject);
				shielded = false;
			}
			other.gameObject.SetActive (false);

		}

	}


}