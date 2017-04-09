using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour {

	public GameObject DeathMenu;
	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") 
		{
			DeathMenu.SetActive (true);
			collision.gameObject.SetActive (false);
			GameObject.Find ("ScoreManager").SetActive (false);
		}
	}
}
