using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleUp : Observable {

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			Notify (other.gameObject, "DoubleUp");
			gameObject.SetActive (false);
		}
	}
}
