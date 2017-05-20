using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : Observable {

	private GameObject character;
	private bool dirtyFlag = false;
	private Vector3 originaScale;
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
		gameObject.name = "Shield";
		dirtyFlag = true;
		GetComponent<CircleCollider2D> ().enabled = false;
		originaScale = transform.localScale;
		transform.localScale += new Vector3 (0.2f, 0.2f, 0);
	}
	public void reset()
	{
		character = null;
		dirtyFlag = false;
		GetComponent<CircleCollider2D> ().enabled = true;
		gameObject.name = "Shield(Clone)";
		transform.localScale = originaScale;
	}
	void OnTriggerEnter2D(Collider2D other) 
	{

		if (other.gameObject.tag == "Danger" || other.gameObject.tag == "DecreasePickUp" || other.gameObject.tag == "SlowDown") 
		{
			Notify (gameObject, "Protected", other.gameObject);
		}

	}	
}
