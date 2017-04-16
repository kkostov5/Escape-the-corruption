using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : View
{
	void Start(){}
	void Update(){}
	void OnTriggerEnter2D(Collider2D other) 
	{
		Debug.Log ("Collision");

		if (other.gameObject.tag == "Death" && gameObject.tag == "Character") 
		{
			Notify (gameObject, "Death");
		}

		else if (other.gameObject.tag == "Death") 
		{
			Debug.Log ("Deactivate");
			Notify (gameObject, "Deactivate");
		}
	}
}
