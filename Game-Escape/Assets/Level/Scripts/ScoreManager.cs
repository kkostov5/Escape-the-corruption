using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text score;
	public Text highscore;

	public float scoreCount;
	public float highscoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;
	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey ("HighScore"))highscoreCount = PlayerPrefs.GetFloat ("HighScore");
	}
	
	// Update is called once per frame
	void Update () {

		scoreCount += pointsPerSecond * Time.deltaTime;
		if(highscoreCount < scoreCount)
		{
			highscoreCount = scoreCount;
			PlayerPrefs.SetFloat ("HighScore",highscoreCount);
		}
		score.text = "Score: " + Mathf.Round(scoreCount);
		highscore.text = "High Score: " + Mathf.Round(highscoreCount);
	}
}
