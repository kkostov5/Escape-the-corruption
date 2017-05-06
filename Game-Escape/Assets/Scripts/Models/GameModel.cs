using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel: Observable {
	
	private float _speed = 0.13f;
	private float _speedMultiplier = 1.05f;
	private float _speedTarget = 1f;
	private float _speedRatio = 1f;
	private float _time = 0f;
	public ObjectPooler tilePooler;
	public ObjectPooler coinPooler;
	public ObjectPooler spikePooler;
//	private float _dangerRate = 0f;
//	private float _coinRate = 50f;
//	private float _platformDistanceMax = 6f;
//	private float _platformDistanceMin = 3f;
	private float _platformHeightDifference;
	public float _platformHeightMax = 6f;
	private float _platformHeightMin;
	private float _score = 0f;
	private float _highScore;
	private float _scoreMultiplier = 5;

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
	/// Increases the score.
	/// </summary>
	/// <param name="time">Time.</param>
	public void increaseScore(float time)
	{
		_score = _score + (_scoreMultiplier * time);
		if (_score > _highScore) 
		{
			_highScore = _score;
			PlayerPrefs.SetFloat ("HighScore",highScore);
		}
	}
	/// <summary>
	/// Gets or sets the speed.
	/// </summary>
	/// <value>The speed.</value>
	public float Speed { get { return _speed; }set{ _speed = value;}}
	public void updateSpeed(float time)
	{
		_time += time;
		if (_speed*_time > _speedTarget) {
			_speed = _speed * _speedMultiplier;
			_speedRatio = _speedRatio * _speedMultiplier;
			_speedTarget += _speedRatio;
			Notify (null,"SpeedUpdate");

		}
	}
	/// <summary>
	/// Gets or sets the score.
	/// </summary>
	/// <value>The score.</value>
	public float Score { get { return _score; }set{ _score = value;}}
	/// <summary>
	/// Gets or sets the high score.
	/// </summary>
	/// <value>The high score.</value>
	public float highScore { get { return _highScore; }set{ _highScore = value;}}
	/// <summary>
	/// Gets or sets the score multiplier.
	/// </summary>
	/// <value>The score multiplier.</value>
	public float scoreMultiplier { get { return _speedMultiplier; }set{ _speedMultiplier = value;}}

		
}
