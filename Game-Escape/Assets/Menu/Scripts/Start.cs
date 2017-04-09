using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour {

	public string Level;


	public void StartLevel()
	{
		Application.LoadLevel(Level);
	}
}
