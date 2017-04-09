using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpCoins : MonoBehaviour {

	public int scoreEquivilant;

	private ScoreManager scoreManager;
	// Use this for initialization
	void Start () {
		scoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") 
		{
			scoreManager.scoreCount += scoreEquivilant;
			gameObject.SetActive (false);
		}
	}
}
