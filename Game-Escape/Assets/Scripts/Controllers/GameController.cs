using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class GameController : MonoBehaviour, Observer {

	public ObjectPooler tilePooler;
	public ObjectPooler coinPooler;
	public ObjectPooler virusPooler;

	private GameModel model;

	private Text score;
	private Text highscore;

	public GameObject last;
	public GameObject generationPoint;


	void Start()
	{
		model = new GameModel ();

		score = GameObject.Find ("ScoreText").GetComponent<Text>();
		highscore = GameObject.Find ("HighScoreText").GetComponent<Text>();

		Time.timeScale = 1f;
	}

	void Update()
	{
		if (Time.timeScale != 0f) {
			

			if (last.transform.position.x < generationPoint.transform.position.x - model.Platform.getPlatformDistance()) { //fix range
				generatePlatform (generationPoint);
			}
			model.GameSpeed.updateSpeed (Time.deltaTime);

			model.Score.increaseScore (Time.deltaTime);
			score.text = "Score: " + Mathf.Round (model.Score.score);
			highscore.text = "High Score: " + Mathf.Round (model.Score.highScore);
		}

	}

	public void Operation(Object o, string operation)
	{
		if (operation == "Death") {
			Time.timeScale = 0f;
			model.GameSpeed.stopSpeed();
		}
		if (operation == "Pause") {
			Time.timeScale = 0f;
			model.GameSpeed.stopSpeed();
		}
		else if (operation == "Resume") {
			Time.timeScale = 1f;
			model.GameSpeed.resetSpeed();
		}
		if (operation == "CoinCollection") 
		{
			model.Score.increaseScore (20);
			GameObject obj = (GameObject) o;
			obj.SetActive(false);
		}
	}



	/// <summary>
	/// Generates the platform.
	/// </summary>
	/// <param name="o">O.</param>
	public void generatePlatform(GameObject obj)
	{
		float positionX = obj.transform.position.x;
		float height= model.Platform.getPlatformHeight (last.transform.position.y);

		GameObject tile;
		bool coinCheck = false;
		bool virusCheck = false;


		for (int i = 1; i <= model.Platform.getPlatformWidth(); i++) 
		{
			tile = tilePooler.getObject ();
			if (i != 1)
				positionX += 1f;
			
			tile.transform.position = new Vector2 (positionX, height);
			tile.SetActive (true);

			last = tile;

			if (!coinCheck) 
			{
				coinCheck = generateItem(model.Coin,coinPooler,tile);

			}
			if (!virusCheck) 
			{
				virusCheck = generateItem(model.Warning,virusPooler,tile);
			}
		}

	}

	/// <summary>
	/// Generates the item.
	/// </summary>
	/// <returns><c>true</c>, if item was generated, <c>false</c> otherwise.</returns>
	/// <param name="item">Item.</param>
	/// <param name="pool">Pool.</param>
	/// <param name="platform">Platform.</param>
	public bool generateItem(Item item, ObjectPooler pool, GameObject platform)
	{
		if (Random.Range (0f, 100f) < item.Threshold) 
		{
			GameObject obj = pool.getObject();
			obj.transform.position = platform.transform.position+new Vector3 (0f, 1.5f, 0f);
			obj.SetActive (true);
			return true;
		}
		return false;
	}

}
