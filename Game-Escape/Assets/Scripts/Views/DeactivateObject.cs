using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : Observable
{
	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Death") 
		{
			gameObject.SetActive (false);
		}
	}
}
