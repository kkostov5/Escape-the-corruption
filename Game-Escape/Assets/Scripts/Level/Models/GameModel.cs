using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel {
	

	private List<Item> collectibles;
//	private Item coin;
//	private Item warning;
//	private Item collectible;
	private Platform platform;

	private Speed gameSpeed;

	public GameModel()
	{
		collectibles = new List<Item> ();
		Item goodPickUp = new Item (40);
		Item badPickUp = new Item (15);
		Item slowDown = new Item (5);
		Item doubleUp = new Item (5);
		Item shield = new Item (5);
		Item virus = new Item (5);
		collectibles.Add (goodPickUp);
		collectibles.Add (badPickUp);
		collectibles.Add (slowDown);
		collectibles.Add (doubleUp);
		collectibles.Add (shield);
		collectibles.Add (virus);
		platform = new Platform (6,3,1,3,-8.5f,9,7);
		gameSpeed = new Speed (0.13f,1.03f,1f,0.23f);

	}
		
	public List<Item> Collectibles {get {return collectibles;}set {collectibles = value;}}
	public Platform Platform {get {return platform;}set {platform = value;}}
	public Speed GameSpeed {get {return gameSpeed;}set {gameSpeed = value;}}
}
