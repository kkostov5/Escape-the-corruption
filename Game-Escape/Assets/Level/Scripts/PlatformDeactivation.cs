using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeactivation : MonoBehaviour {

	private GameObject platformToDestroy;

	// Use this for initialization
	void Start () {
		platformToDestroy = GameObject.Find ("PlatformDeactivationPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformToDestroy.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
		
	}
}
