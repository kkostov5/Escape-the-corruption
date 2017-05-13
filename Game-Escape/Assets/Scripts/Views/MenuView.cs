using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : Observable {

	public void Pause()
	{
		Notify (gameObject,"Pause");
	}
	public void Resume()
	{
		Notify (gameObject,"Resume");
	}
	public void Restart()
	{
		Notify (gameObject,"Restart");
	}
	public void MainMenu()
	{
		Notify (gameObject,"BackToMain");
	}
	public void SaveScore()
	{
		Notify (gameObject,"SaveScore");
	}
}
