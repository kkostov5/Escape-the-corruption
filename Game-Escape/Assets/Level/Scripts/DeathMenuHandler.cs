using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuHandler : MonoBehaviour {

	public string mainMenuLevel;

	public void RestartGame()
	{
		Scene scene = SceneManager.GetActiveScene(); 
		SceneManager.LoadScene(scene.name);
	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene(mainMenuLevel);
	}
}
