using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel {
	
	private Score score;

	private Item coin;
	private Item warning;
	private Platform platform;

	private Speed gameSpeed;

	public GameModel()
	{
		score = new Score ();
		coin = new Item ( 20);
		warning = new Item (2);
		platform = new Platform (6,3,2,3,-9,9,2);
		gameSpeed = new Speed (0.13f,1.02f,1);

	}

	public Score Score { get { return score; }}
	public Item Coin {get {return coin;}set {coin = value;}}
	public Item Warning {get {return warning;}set {warning = value;}}
	public Platform Platform {get {return platform;}set {platform = value;}}
	public Speed GameSpeed {get {return gameSpeed;}set {gameSpeed = value;}}

	/// <summary>
	/// Increases the difficulty.
	/// </summary>
	public void increaseDifficulty()
	{

	}





		
}
