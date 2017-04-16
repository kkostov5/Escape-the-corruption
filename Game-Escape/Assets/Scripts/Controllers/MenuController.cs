using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour, Observer {

	public GameObject PauseMenu;
	public GameObject DeathMenu;

	public void update(Object o, string args)
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (args == "Pause") {
			PauseMenu.SetActive (true);
			player.GetComponent<CharacterView>().enabled = false;
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		}
		else if (args == "BackToMain") {
			SceneManager.LoadScene("Menu");
		}
		else if (args == "Restart") {
			
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}
		else if (args == "Resume") {
			PauseMenu.SetActive (false);
			player.GetComponent<CharacterView>().enabled = true;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		}
		else if (args == "Death") {
			DeathMenu.SetActive (true);
			player.GetComponent<CharacterView>().enabled = false;
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
		}
			
	}
}
