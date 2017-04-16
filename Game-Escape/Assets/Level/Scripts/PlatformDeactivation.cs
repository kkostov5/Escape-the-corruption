using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeactivation : MonoBehaviour {

	public GameObject platformToDestroy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformToDestroy.transform.position.x) 
		{
			gameObject.SetActive (false);
		}
		
	}
}
