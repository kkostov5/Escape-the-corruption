using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel {
	
	private float _speed = 0.13f;
	private float _speedMultiplier = 1.02f;
	private float _speedTarget = 1f;
	private float _speedRatio = 1f;
	private float _time = 0f;
//	private float _dangerRate = 0f; 
//	private float _coinRate = 50f;
//	private float _platformDistanceMax = 6f;
//	private float _platformDistanceMin = 3f;
	private float _platformHeightDifference;
	public float _platformHeightMax = 6f;
	private float _platformHeightMin;
	private Score _score;

	public GameModel()
	{
		_score = new Score ();
	}
	public Score Score { get { return _score; }}
	public float Speed { get { return _speed; }set{ _speed = value;}}

	/// <summary>
	/// Increases the difficulty.
	/// </summary>
	public void increaseDifficulty()
	{
//		speed = speed*speedMultiplier;
//		speedRatio = speedRatio * speedMultiplier;
//		target += speedRatio;
//		dangerRate += 0.5f;
	}

	/// <summary>
	/// Updates the speed.
	/// </summary>
	/// <param name="time">Time.</param>
	public void updateSpeed(float time)
	{
		_time += time;
		if (_speed*_time > _speedTarget) {
			_speed = _speed * _speedMultiplier;
			_speedRatio = _speedRatio * _speedMultiplier;
			_speedTarget += _speedRatio;
			//Notify (null,"SpeedUpdate");// Callback/Return variables

		}
	}



		
}
