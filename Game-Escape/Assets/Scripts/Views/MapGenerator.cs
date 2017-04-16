using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : View {

	public GameObject generationPoint;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.transform.position.x) 
		{
			Notify (gameObject, "Generate Platform");
		}
	}
}
