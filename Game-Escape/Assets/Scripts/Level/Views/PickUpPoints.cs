using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : Observable {

	void OnTriggerEnter2D(Collider2D other) 
	{
		 if (other.gameObject.tag == "Player") 
		{
			Notify (other.gameObject, "PickUpPoints");
			gameObject.SetActive (false);
		}
	}
}
