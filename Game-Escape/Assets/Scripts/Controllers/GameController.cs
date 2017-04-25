using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour, Observer {

	public GameModel model;
	private float speed;
	private Text score;
	private Text highscore;
	private bool pause;

	public void update(Object o, string args)
	{
		GameObject obj = (GameObject)o;
		if (args == "Generate Platform") 
		{
			
			float distanceBetween = Random.Range (model.platformDistanceMin, model.platformDistanceMax);
			float platformWidth = Random.Range (2, 9);
			bool coinCheck = false;
			bool spikeCheck = false;
			float platformHeightChange = obj.transform.position.y + Random.Range (model.platformHeightDifference, -model.platformHeightDifference);
			platformHeightChange = Mathf.Clamp (platformHeightChange, model.platformHeightMin, model.platformHeightMax);

			for (int i = 1; i <= platformWidth; i++) {
				GameObject newPlatform = (GameObject) model.tilePooler.getObject ();
				if (i == 1)
					obj.transform.position = new Vector3 (obj.transform.position.x + 0.99f + distanceBetween, platformHeightChange, obj.transform.position.z);
				else
					obj.transform.position = new Vector3 (obj.transform.position.x + 1f, platformHeightChange, obj.transform.position.z);
				newPlatform.transform.position = obj.transform.position;
				newPlatform.transform.rotation = obj.transform.rotation;
				newPlatform.SetActive (true);
				newPlatform.GetComponent<Speed> ().speed = model.speed;
				if (Random.Range (0f, 100f) < model.coinRate && !coinCheck) {
					GameObject coin = model.coinPooler.getObject ();
					Vector3 coinPosition = new Vector3 (0f, 1.5f, 0f);
					coin.transform.position = obj.transform.position + coinPosition;
					coin.SetActive (true);
					coinCheck = true;

				}
				if (Random.Range (0f, 100f) < model.dangerRate && !spikeCheck) {
					GameObject spike = model.spikePooler.getObject ();
					Vector3 spikePosition = new Vector3 (0f, spike.GetComponent<BoxCollider2D> ().size.y / 2, 0f);
					spike.transform.position = obj.transform.position + spikePosition;
					spike.SetActive (true);
					spikeCheck = true;
				}
			}
		}
		if (args == "Pause") 
		{
			pause = true;
			speed = model.speed;
			model.speed = 0;
		}
		if (args == "Resume") 
		{
			pause = false;
			model.speed = speed;
		}
	}

	void Start()
	{
		pause = false;
		if(PlayerPrefs.HasKey ("HighScore"))model.highscore = PlayerPrefs.GetFloat ("HighScore");
		score = GameObject.Find ("ScoreText").GetComponent<Text>();
		highscore = GameObject.Find ("HighScoreText").GetComponent<Text>();

	}

	void Update()
	{
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("Ground");
		foreach(GameObject obj in tiles)
		{
			if(obj!=null && obj.GetComponent<Speed>()!=null)
			{
				obj.GetComponent<Speed>().speed = model.speed;
			}
		}
		if(!pause)model.increaseScore(Time.deltaTime);
		score.text = "Score: " + Mathf.Round(model.score);
		highscore.text = "High Score: " + Mathf.Round(model.highscore);
	}
}
