using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highscoreText;

	public static float score;
	public float highscore;

	public float pointsPerSecond;

	// Use this for initialization
	void Start () 
	{
		score = 0f;
		if(PlayerPrefs.HasKey ("HighScore"))highscore = PlayerPrefs.GetFloat ("HighScore");
	}
	
	// Update is called once per frame
	void Update () {

		AddScore(pointsPerSecond * Time.deltaTime);
		if(highscore < score)
		{
			highscore = score;
			PlayerPrefs.SetFloat ("HighScore",highscore);
		}
		scoreText.text = "Score: " + Mathf.Round(score);
		highscoreText.text = "High Score: " + Mathf.Round(highscore);
	}

	public static void AddScore(float increase)
	{
		score += increase;
	}
}
