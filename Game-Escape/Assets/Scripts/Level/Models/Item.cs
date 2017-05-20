using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	private float rate;

	public Item(float rate)
	{
		this.rate = rate;
	}
		

	public float Rate {
		get {
			return rate;
		}
		set {
			rate = value;
		}
	}
}
