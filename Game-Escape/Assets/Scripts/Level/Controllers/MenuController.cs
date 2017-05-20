using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour, Observer {

	public GameObject DeathMenu;
	public GameObject button;

	public void Operation(Object obj, string operation,params object[] data)
	{
		if (operation == "BackToMain") {
			Time.timeScale = 1f;
			SceneManager.LoadScene("Menu");
		}
		else if (operation == "Pause") {
			Time.timeScale = 0f;
			button.SetActive (false);
		}
		else if (operation == "Restart") {

			Time.timeScale = 1f;
			Scene scene = SceneManager.GetActiveScene(); 
			SceneManager.LoadScene(scene.name);
		}
		else if (operation == "Resume") {
			Time.timeScale = 1f;
			button.SetActive (true);
		}
		else if (operation == "Death") {
			Time.timeScale = 0f;
			DeathMenu.SetActive (true);
			button.SetActive (false);
		}
			
	}
}
