using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel {
	
	private Score score;

	private List<Item> collectibles;
//	private Item coin;
//	private Item warning;
//	private Item collectible;
	private Platform platform;

	private Speed gameSpeed;

	public GameModel()
	{
		score = new Score ();
		collectibles = new List<Item> ();
		Item coin = new Item (20);
		Item warning = new Item (5);
		Item slowDown = new Item (10);
		Item doubleUp = new Item (10);
		collectibles.Add (coin);
		collectibles.Add (warning);
		collectibles.Add (slowDown);
		collectibles.Add (doubleUp);
		platform = new Platform (6,3,2,3,-9,9,7);
		gameSpeed = new Speed (0.13f,1.02f,1,0.23f);

	}

	public Score Score { get { return score; }}
	//public Item Coin {get {return coin;}set {coin = value;}}
	public List<Item> Collectibles {get {return collectibles;}set {collectibles = value;}}
	//public Item Warning {get {return warning;}set {warning = value;}}
	public Platform Platform {get {return platform;}set {platform = value;}}
	public Speed GameSpeed {get {return gameSpeed;}set {gameSpeed = value;}}
}
