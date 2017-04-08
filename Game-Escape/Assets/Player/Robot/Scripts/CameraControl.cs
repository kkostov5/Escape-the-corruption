using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public GameObject character;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		character = GameObject.FindGameObjectWithTag ("Player");
		offset = transform.position - character.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = character.transform.position + offset;
	}
}
