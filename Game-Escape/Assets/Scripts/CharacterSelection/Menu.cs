using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
	public void back()
	{
		SceneManager.LoadScene("Menu");
	}

	public void next()
	{
		SceneManager.LoadScene("LevelScene");
	}
}
