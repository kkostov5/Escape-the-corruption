using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 updated = new Vector2 (transform.position.x-Speed.getSpeed(),transform.position.y);
		transform.position = updated;
	}
}
