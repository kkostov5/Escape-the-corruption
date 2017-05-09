using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Observable {

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject.tag == "Player") 
		{
			Notify (gameObject, "CoinCollection");
		}
	}
}
