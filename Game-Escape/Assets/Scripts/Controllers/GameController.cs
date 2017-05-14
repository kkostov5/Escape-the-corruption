using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class GameController : MonoBehaviour, Observer {

	public ObjectPooler[] collectiblePools;
	public ObjectPooler tilePooler;
	private GameModel model;

	private Text score;
	private Text highscore;

	public GameObject last;
	public GameObject generationPoint;

	private float probabilityOfItems;


	void Start()
	{
		model = new GameModel ();

		probabilityOfItems = 100;
		score = GameObject.Find ("ScoreText").GetComponent<Text>();
		highscore = GameObject.Find ("HighScoreText").GetComponent<Text>();

	}

	void FixedUpdate()
	{
		if (Time.timeScale != 0f) {
			

			if (last.transform.position.x < generationPoint.transform.position.x - model.Platform.getPlatformDistance()) { //fix range
				generatePlatform (generationPoint);
			}

			if (model.GameSpeed.updateSpeed (Time.deltaTime))
				increaseDifficulty ();

			model.Score.increaseScore (Time.deltaTime);

			score.text = "Score: " + Mathf.Round (model.Score.score);
			highscore.text = "High Score: " + Mathf.Round (model.Score.highScore);
		}

	}

	public void Operation(Object o, string operation,params object[] data)
	{
		if (operation == "Death" || operation == "Pause") {
			model.GameSpeed.stopSpeed();
		}
		else if (operation == "Resume") {
			model.GameSpeed.resetSpeed();
		}
		if (operation == "CoinCollection") 
		{
			model.Score.increaseScore (20);
		}
		if (operation == "SaveScore") 
		{
			StartCoroutine (SaveScore (data[0].ToString(),Mathf.Round (model.Score.score)));

		}
		if (operation == "DoubleUp") 
		{
			lock(StartCoroutine(DoubleUp ()));

		}
		if (operation == "ShieldUp") 
		{
			GameObject shield = (GameObject)o;
			GameObject character = (GameObject)data[0];
			shield.GetComponent<SpeedScript> ().enabled = false;
			shield.GetComponent<ShieldScript> ().setCharacter (character);
		}
		if (operation == "SlowDown") 
		{
			StartCoroutine(SlowDown ());
		}
		if (operation == "Protected") 
		{
			GameObject shield = (GameObject)o;
			GameObject danger = (GameObject)data[0];
			shield.SetActive (false);
			danger.SetActive (false);
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
//		bool coinCheck = false;
//		bool virusCheck = false;
		int numberColl = 2;

		for (int i = 1; i <= model.Platform.getPlatformWidth(); i++) 
		{
			tile = tilePooler.getObject ();
			if (i != 1)
				positionX += 1f;
			
			tile.transform.position = new Vector2 (positionX, height);
			tile.SetActive (true);

			last = tile;

			if(numberColl>0){
				if (generateItemOnTile (tile))
				numberColl--;
			}
//			if (!coinCheck) 
//			{
//				coinCheck = generateItem(model.Coin,coinPooler,tile);
//
//			}
//			if (!virusCheck) 
//			{
//				virusCheck = generateItem(model.Warning,virusPooler,tile);
//			}
		}

	}

	public bool generateItemOnTile(GameObject platform)
	{

		if(Random.Range(0,1000)<probabilityOfItems)
		{
			float range = 0;
			for (int i = 0; i < model.Collectibles.Count; i++)
				range += model.Collectibles [i].Rate;
			float randomNumber = Random.Range (0,range);
			float rangeMax = 0;
			float rangeMin = 0;
			for (int i = 0; i < model.Collectibles.Count; i++)
			{
				
				rangeMax += model.Collectibles [i].Rate;
				if (randomNumber >= rangeMin && randomNumber<=rangeMax) 
				{
					generateItem (collectiblePools[i],platform);
					return true;
				}
				rangeMin += model.Collectibles [i].Rate;
			}
		}
		return false;
	}
	
	public void generateItem(ObjectPooler pool, GameObject platform)
	{
		GameObject obj = pool.getObject();
		obj.transform.position = platform.transform.position+new Vector3 (0f, 1.5f, 0f);
		obj.SetActive (true);
	}


	/// <summary>
	/// Increases the difficulty.
	/// </summary>
	public void increaseDifficulty()
	{
		if(model.Platform.MinWidth>2)
		{
			model.Platform.MinWidth--;
		}
		for (int i = 0; i < model.Collectibles.Count; i++)
		{

			model.Collectibles [i].Rate += 0.5f;
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

	IEnumerator DoubleUp(){
		Debug.Log ("DoubleUp");
		Color text = score.color;
		score.color = Color.yellow;
		model.Score.scoreMultiplier = 2f; 
		yield return new WaitForSeconds(10);
		score.color = text;
		model.Score.scoreMultiplier = 1f; 
	}

	IEnumerator SlowDown(){
		Debug.Log ("HSADFASFas");
		float speed = model.GameSpeed.SpeedValue;
		model.GameSpeed.SpeedValue = speed / 1.5f;
		yield return new WaitForSecondsRealtime(10);
		if(model.GameSpeed.SpeedValue!=0)model.GameSpeed.SpeedValue = speed ;
	}


}
