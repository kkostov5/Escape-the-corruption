using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : View {


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Debug.Log ("Jump Key Pressed");
			Notify (gameObject, "Jump");
		}
	}


}
