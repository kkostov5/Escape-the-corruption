using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 updated = new Vector2 (transform.position.x-speed,transform.position.y);
		transform.position = updated;
	}

	public void UpdateSpeed(float speed)
	{
		this.speed = speed;
	}
}
