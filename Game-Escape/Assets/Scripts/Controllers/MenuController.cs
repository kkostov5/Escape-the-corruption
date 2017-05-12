using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour, Observer {

	public GameObject PauseMenu;
	public GameObject DeathMenu;
	public GameObject button;

	public void Operation(Object obj, string operation)
	{
		if (operation == "Pause") {
			PauseMenu.SetActive (true);
		}
		else if (operation == "BackToMain") {
			Time.timeScale = 1f;
			SceneManager.LoadScene("Menu");
		}
		else if (operation == "Restart") {

			Time.timeScale = 1f;
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}
		else if (operation == "Resume") {
			PauseMenu.SetActive (false);
		}
		else if (operation == "Death") {
			DeathMenu.SetActive (true);
			button.SetActive (false);
		}
			
	}
}
