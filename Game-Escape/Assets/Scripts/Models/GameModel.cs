using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour {
	
	public float speed = 10f;
	public float speedMultiplier;
	public float speedTarget;
	private float speedRatio;
	public ObjectPooler tilePooler;
	public ObjectPooler coinPooler;
	public ObjectPooler spikePooler;
	public float dangerspawning;
	public float coinspawning;

	public void updateSpeed()
	{
		speed = speed*speedMultiplier;
		speedRatio = speedRatio * speedMultiplier;
		speedTarget += speedRatio;
	}

	public void increaseDifficulty(float difference)
	{
		dangerspawning += difference;
		coinspawning -= difference;
	}
}
