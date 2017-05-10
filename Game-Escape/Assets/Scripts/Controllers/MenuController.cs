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
			Time.timeScale = 0f;
		}
		else if (operation == "BackToMain") {
			SceneManager.LoadScene("Menu");
		}
		else if (operation == "Restart") {
			
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
			Time.timeScale = 1f;
		}
		else if (operation == "Resume") {
			PauseMenu.SetActive (false);
			Time.timeScale = 1f;
		}
		else if (operation == "Death") {
			DeathMenu.SetActive (true);
			button.SetActive (false);
			Time.timeScale = 0f;
		}
			
	}
}
