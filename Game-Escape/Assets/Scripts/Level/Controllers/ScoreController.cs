using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour,Observer {

	private Text score;
	private Text highscore;

	private Score model;

	private bool multiplied = false;

	// Use this for initialization
	void Start () {

		model = new Score ();

		score = GameObject.Find ("ScoreText").GetComponent<Text>();
		highscore = GameObject.Find ("HighScoreText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0f) {

			model.increaseScore (Time.deltaTime);

			score.text = "Score: " + Mathf.Round (model.score);
			highscore.text = "High Score: " + Mathf.Round (model.highScore);
		}
	}
	/// <summary>
	/// Operations done according to Observables notifications
	/// </summary>
	/// <param name="o">O.</param>
	/// <param name="operation">Operation.</param>
	/// <param name="data">Data.</param>
	public void Operation(Object o, string operation,params object[] data)
	{
		if (operation == "PickUpPoints") 
		{
			model.increaseScore (20);
		}
		else if (operation == "DecreasePickUp") 
		{
			model.increaseScore (-20);
			GameObject obj = (GameObject)o;
			obj.SetActive (false);
		}
		else if (operation == "SaveScore") 
		{
			StartCoroutine (SaveScore (data[0].ToString(),Mathf.Round (model.score)));

		}
		else if (operation == "DoubleUp") 
		{
			if(!multiplied)
			{
				StartCoroutine (DoubleUp ());
			}
		}
	}

	/// <summary>
	/// Saves the score.
	/// </summary>
	/// <returns>The score.</returns>
	/// <param name="username">Username.</param>
	/// <param name="score">Score.</param>
	IEnumerator SaveScore(string username, float score){
		string SavingScore = "https://zeno.computing.dundee.ac.uk/2016-ac32006/krasimirkostov/SavingScore.php";
		WWWForm form = new WWWForm();
		form.AddField("name", username);
		form.AddField("score", (int) score);
		WWW www = new WWW(SavingScore, form);
		yield return www;
	}

	/// <summary>
	/// Doubles up.
	/// </summary>
	/// <returns>The up.</returns>
	IEnumerator DoubleUp(){

		multiplied = true;
		Color text = score.color;
		score.color = Color.green;
		model.scoreMultiplier = 2f; 
		yield return new WaitForSeconds(10);
		score.color = text;
		model.scoreMultiplier = 1f; 
		multiplied = false;
	}
}
