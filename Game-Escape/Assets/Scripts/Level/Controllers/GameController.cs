using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;


public class GameController : MonoBehaviour, Observer {

	public ObjectPooler[] collectiblePools;
	public ObjectPooler tilePooler;
	private GameModel model;



	public GameObject last;
	public GameObject generationPoint;

	private float probabilityOfItems;

	private bool multiplied = false;

	void Start()
	{
		model = new GameModel ();

		probabilityOfItems = 15f;


	}

	void FixedUpdate()
	{
		if (Time.timeScale != 0f) {
			

			if (last.transform.position.x < generationPoint.transform.position.x - model.Platform.getPlatformDistance()) { //fix range
				generatePlatform (generationPoint);
			}

			if (model.GameSpeed.updateSpeed (Time.deltaTime))
				increaseDifficulty ();

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
		if (operation == "Death" || operation == "Pause") {
			model.GameSpeed.stopSpeed();
		}
		else if (operation == "Resume") {
			model.GameSpeed.resetSpeedMenu();
		}
		else if (operation == "DoubleUp") 
		{
			if(!multiplied)
			{
				StartCoroutine (DoubleUp ());
			}
		}
		else if (operation == "ShieldUp") 
		{
			GameObject shield = (GameObject)o;
			GameObject character = (GameObject)data [0];
			shield.GetComponent<SpeedScript> ().enabled = false;
			shield.GetComponent<ShieldScript> ().setCharacter (character);
		}
		else if (operation == "SlowDown") 
		{
			StartCoroutine(SlowDown ());
		}
		else if (operation == "Protected") 
		{
			GameObject character = (GameObject)o;
			GameObject danger = (GameObject)data[0];
			GameObject shield = GameObject.Find ("Shield");
			shield.GetComponent<ShieldScript> ().reset ();
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
		}

	}

	/// <summary>
	/// Generates the item on tile.
	/// </summary>
	/// <returns><c>true</c>, if item on tile was generated, <c>false</c> otherwise.</returns>
	/// <param name="platform">Platform.</param>
	public bool generateItemOnTile(GameObject platform)
	{
		if(Random.Range(0,100) < probabilityOfItems)
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

	/// <summary>
	/// Generates the item.
	/// </summary>
	/// <param name="pool">Pool.</param>
	/// <param name="platform">Platform.</param>
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
		if(model.Platform.MinWidth>2 )
		{
			model.Platform.MinWidth--;
		}
		if(model.Collectibles [0].Rate > 30)model.Collectibles [0].Rate -= 0.5f;
		if(model.Collectibles [1].Rate < 30)model.Collectibles [0].Rate += 0.5f;
		if(model.Collectibles [2].Rate < 30)model.Collectibles [0].Rate += 0.3f;
		if(model.Collectibles [3].Rate < 30)model.Collectibles [0].Rate += 0.3f;
		if(model.Collectibles [4].Rate < 30)model.Collectibles [0].Rate += 0.3f;
		if(model.Collectibles [5].Rate < 30)model.Collectibles [0].Rate += 0.3f;
		probabilityOfItems += 2;


	}
		

	/// <summary>
	/// Doubles up.
	/// </summary>
	/// <returns>The up.</returns>
	IEnumerator DoubleUp(){

		multiplied = true;
		float coinRate = model.Collectibles [0].Rate;
		float doubleRate = model.Collectibles [3].Rate;
		model.Collectibles [3].Rate = 0f;
		model.Collectibles [0].Rate += 10f;
		yield return new WaitForSeconds(10);
		model.Collectibles [0].Rate = coinRate;
		model.Collectibles [3].Rate = doubleRate;
		multiplied = false;
	}

	/// <summary>
	/// Slows down.
	/// </summary>
	/// <returns>The down.</returns>
	IEnumerator SlowDown(){
		model.GameSpeed.slowSpeed (1.5f);
		yield return new WaitForSeconds(10);
		model.GameSpeed.resetSpeed() ;
	}


}
