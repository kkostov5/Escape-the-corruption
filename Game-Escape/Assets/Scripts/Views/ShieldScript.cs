using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : Observable {

	private GameObject character;
	private bool dirtyFlag = false;
	private Vector3 offset = new Vector3(0,0.01f,0);
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if(dirtyFlag)transform.position = (character.transform.position-offset);
	}

	public void setCharacter(GameObject obj)
	{
		character = obj;
		transform.parent = character.transform;
		dirtyFlag = true;
		GetComponent<CircleCollider2D> ().enabled = false;
		//gameObject.transform.localScale = 
	}
	public void reset(GameObject obj)
	{
		character = null;
		transform.parent = obj.transform;
		dirtyFlag = false;
		GetComponent<CircleCollider2D> ().enabled = true;
	}
		
}
