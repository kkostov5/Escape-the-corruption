using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GameController : MonoBehaviour, Observer {

	public GameModel model;
	private float speed;
	private Text score;
	private Text highscore;
	private bool pause;
	private GameObject MapGenerator;
	private Thread th;
	public GameObject last;
	public float maxHeight;
	public float minHeight;
	public GameObject generationPoint;

	public void Operation(Object o, string operation)
	{
		if (operation == "Pause" || operation == "Death") 
		{
			pause = true;
			speed = model.Speed;
			model.Speed = 0;
			speedAlteration ();
		}
		if (operation == "Resume") 
		{
			pause = false;
			model.Speed = speed;
			speedAlteration ();
		}
	}

	void Start()
	{
		
		pause = false;
		if(PlayerPrefs.HasKey ("HighScore"))model.highScore = PlayerPrefs.GetFloat ("HighScore");
		score = GameObject.Find ("ScoreText").GetComponent<Text>();
		highscore = GameObject.Find ("HighScoreText").GetComponent<Text>();
		speedAlteration ();
	}

	void Update()
	{
		if (!pause) {
			model.increaseScore (Time.deltaTime);
			if (last.transform.position.x < generationPoint.transform.position.x - Random.Range (3,6)) {
				GeneratePlatform(generationPoint);
			}
		}
		score.text = "Score: " + Mathf.Round(model.Score);
		highscore.text = "High Score: " + Mathf.Round(model.highScore);

	}

	public void speedAlteration()
	{
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("Ground");
		foreach(GameObject obj in tiles)
		{
			if(obj!=null && obj.GetComponent<Speed>()!=null)
			{
				obj.GetComponent<Speed>().speed = model.Speed;
			}
		}
	}
	public void GeneratePlatform(GameObject o)
	{
		int platformWidth = Random.Range (2,9);
		Vector2 current = new Vector2(o.transform.position.x,o.transform.position.y);
		float height = last.transform.position.y + Random.Range(-model._platformHeightMax,model._platformHeightMax);
		height = Mathf.Clamp(height, minHeight, maxHeight);
		GameObject newPlatform;
		for (int i = 1; i <= platformWidth; i++) 
		{
			newPlatform = model.tilePooler.getObject ();
			if(i==1)current = new Vector2 (current.x, height);
			else current = new Vector2 (current.x+ 1f, height);
			newPlatform.transform.position = current;
			newPlatform.GetComponent<Speed> ().UpdateSpeed (model.Speed);
			newPlatform.SetActive (true);
			last = newPlatform;
		}

	}

}
