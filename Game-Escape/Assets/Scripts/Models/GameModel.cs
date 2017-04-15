using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour {
	
	public float speed = 10f;
	public float speedMultiplier = 1.05f;
	public float target = 100f;
	private float speedRatio = 100f;
	public ObjectPooler tilePooler;
	public ObjectPooler coinPooler;
	public ObjectPooler spikePooler;
	public float dangerRate = 0f;
	public float coinRate = 50f;
	public float platformDistanceMax;
	public float platformDistanceMin;
	public float platformHeightDifference;
	public float platformHeightMax;
	public float platformHeightMin;


	public void increaseDifficulty()
	{
		speed = speed*speedMultiplier;
		speedRatio = speedRatio * speedMultiplier;
		target += speedRatio;
		dangerRate += 0.5f;
	}

		
}
