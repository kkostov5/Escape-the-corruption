using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

	private float threshold;

	public Item(float threshold)
	{
		this.threshold = threshold;
	}
		

	public float Threshold {
		get {
			return threshold;
		}
		set {
			threshold = value;
		}
	}
}
