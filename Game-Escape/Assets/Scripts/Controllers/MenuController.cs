using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour, Observer {

	public GameObject PauseMenu;
	public GameObject DeathMenu;

	public void Operation(Object o, string operation)
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");

		if (operation == "Pause") {
			PauseMenu.SetActive (true);
			player.GetComponent<CharacterView>().enabled = false;
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		}
		else if (operation == "BackToMain") {
			SceneManager.LoadScene("Menu");
		}
		else if (operation == "Restart") {
			
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}
		else if (operation == "Resume") {
			PauseMenu.SetActive (false);
			player.GetComponent<CharacterView>().enabled = true;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		}
		else if (operation == "Death") {
			DeathMenu.SetActive (true);
			player.GetComponent<CharacterView>().enabled = false;
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		}
			
	}
}
