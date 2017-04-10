using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour {

	public GameObject PauseMenu;
	public GameObject scoreManager;
	public GameObject player;
	public string mainMenuLevel;
	public void PauseGame()
	{
		PauseMenu.SetActive (true);
		scoreManager.SetActive (false);
		player.SetActive (false);
	}
	public void RestartGame()
	{
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}
	public void ResumeGame()
	{
		player.SetActive (true);
		scoreManager.SetActive (true);
		PauseMenu.SetActive (false);
	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene(mainMenuLevel);
	}
}
