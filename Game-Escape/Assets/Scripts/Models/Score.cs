using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score  {

	private float _score;
	private float _highScore;
	private float _scoreMultiplier;

	/// <summary>
	/// Initializes a new instance of the <see cref="Score"/> class.
	/// </summary>
	/// <param name="score">Score.</param>
	/// <param name="multiplier">Multiplier.</param>
	public Score(float score = 0f,float multiplier = 5f)
	{
		_score = score;
		if(PlayerPrefs.HasKey ("HighScore"))_highScore = PlayerPrefs.GetFloat ("HighScore");
		_scoreMultiplier = multiplier;
	}

	public float highScore {get {return _highScore;}}
	public float score {get {return _score;}}
	public float scoreMultiplier {get {return _scoreMultiplier;}set {_scoreMultiplier = value;}}

	/// <summary>
	/// Increases the score.
	/// </summary>
	/// <returns><c>true</c>, if highscore was increased, <c>false</c> otherwise.</returns>
	/// <param name="points">Points.</param>
	public bool increaseScore(float points)
	{
		_score += points;
		if (_score > _highScore) 
		{
			_highScore = _score;
			PlayerPrefs.SetFloat ("HighScore",_highScore);
			return true;
		}
		return false;
	}
		

}
