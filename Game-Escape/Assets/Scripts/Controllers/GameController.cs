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
		if (operation == "SpeedUpdate") 
		{
			speedAlteration ();
			Debug.Log ("Speed " + model.Speed);
		}
		if (operation == "CoinCollection") 
		{
			model.increaseScore (20);
			GameObject obj = (GameObject) o;
			obj.SetActive(false);
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
			model.increaseTimeScore (Time.deltaTime);
			if (last.transform.position.x < generationPoint.transform.position.x - Random.Range (3,6)) {
				GeneratePlatform(generationPoint);
			}
			model.updateSpeed (Time.deltaTime);
		}
		score.text = "Score: " + Mathf.Round(model.Score);
		highscore.text = "High Score: " + Mathf.Round(model.highScore);

	}

	public void speedAlteration()
	{
		Speed[] tiles = FindObjectsOfType(typeof(Speed)) as Speed[];
		foreach(Speed obj in tiles)
		{
			obj.GetComponent<Speed>().speed = model.Speed;
		}
	}

	public void GeneratePlatform(GameObject o)
	{
		int platformWidth = Random.Range (2,9);
		Vector2 current = new Vector2(o.transform.position.x,o.transform.position.y);
		float height = last.transform.position.y + Random.Range(-model._platformHeightMax,model._platformHeightMax);
		height = Mathf.Clamp(height, minHeight, maxHeight);
		GameObject newPlatform;
		bool coinCheck = false;
		bool virusCheck = false;
		for (int i = 1; i <= platformWidth; i++) 
		{
			newPlatform = model.tilePooler.getObject ();
			if(i==1)current = new Vector2 (current.x, height);
			else current = new Vector2 (current.x+ 1f, height);
			newPlatform.transform.position = current;
			newPlatform.GetComponent<Speed> ().UpdateSpeed (model.Speed);
			newPlatform.SetActive (true);
			last = newPlatform;
			if (Random.Range (0f, 100f) < 100 && !coinCheck) 
			{
				GameObject coin = model.coinPooler.getObject ();
				Vector3 coinPosition = new Vector3 (0f, 1.5f, 0f);
				coin.transform.position = newPlatform.transform.position+coinPosition;
				coin.GetComponent<Speed> ().UpdateSpeed (model.Speed);
				coin.SetActive (true);
				coinCheck = true;

			}
			if (Random.Range (0f, 100f) < -1 && !virusCheck) 
			{
				GameObject virus = model.virusPooler.getObject();
				Vector3 virusPosition = new Vector3 (0f, 1.5f, 0f);
				virus.transform.position = newPlatform.transform.position+virusPosition;
				virus.GetComponent<Speed> ().UpdateSpeed (model.Speed);
				virus.SetActive (true);
				virusCheck = true;
			}
		}

	}

}
