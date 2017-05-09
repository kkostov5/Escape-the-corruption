using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : Observable {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

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
		Debug.Log ("Player");
		if (other.gameObject.tag == "Death") 
		{
			Debug.Log ("Died");
			Notify (gameObject, "Death");
		}
		if (other.gameObject.tag == "Coin") 
		{
			Debug.Log ("Collection");
			Notify (other.gameObject, "CoinCollection");
		}
	}


}