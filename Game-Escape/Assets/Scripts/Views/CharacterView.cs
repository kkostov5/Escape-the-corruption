using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : Observable {


	// Use this for initialization
	void Start () {
		gameObject.GetComponent<SpriteRenderer>().sprite = Character.GetSprite ();
		gameObject.GetComponent<Animator>().runtimeAnimatorController = Character.GetAnim ();
	}

	// Update is called once per frame
	void Update () 
	{

		gameObject.GetComponent<Animator> ().SetFloat ("vSpeed",gameObject.GetComponent<Rigidbody2D>().velocity.y);

		if (Input.GetKeyDown (KeyCode.Space))
		{

			Notify (gameObject, "Jump");
		}
		if (Input.GetKey (KeyCode.Space))
		{
			Notify (gameObject, "Longer Jump");

		}
		if (Input.GetKeyUp (KeyCode.Space))
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
		if (other.gameObject.tag == "Coin") 
		{
			Notify (other.gameObject, "CoinCollection");
		}
	}


}