using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Speed  {

	private static float speed;
	private float speedMultiplier;
	private float speedTarget;
	private float speedRatio;
	private float saveSpeed;
	private float maxSpeed;
	private float time ;
	private Stack<float> decreasedSpeed;

	public Speed(float speed,float speedMultiplier,float speedTarget, float maxSpeed)
	{
		Speed.speed = speed;
		this.speedMultiplier = speedMultiplier;
		this.speedTarget = speedTarget;
		this.maxSpeed = maxSpeed;
		speedRatio = speedTarget;
		time = 0;
		saveSpeed = 0;
		decreasedSpeed = new Stack<float> ();
	}

	public static float getSpeed(){ return Speed.speed;}
	public float SpeedValue {get {return speed;}set {speed = value;}}
	public float SpeedMultiplier {get {return speedMultiplier;}set { speedMultiplier = value; }}
	public float MaxSpeed {	get {return maxSpeed;}set {maxSpeed = value;}}

	/// <summary>
	/// Updates the speed.
	/// </summary>
	/// <param name="time">Time.</param>
	public bool updateSpeed(float timeUpdate)
	{
		time += timeUpdate;
		if (maxSpeed < speed)
			return false;
		if (speed*time > speedTarget) {
			speed = speed * speedMultiplier;
			speedRatio = speedRatio * speedMultiplier;
			speedTarget += speedRatio;
			return true;

		}
		return false;
	}

	/// <summary>
	/// Stops the speed.
	/// </summary>
	public void stopSpeed()
	{
		saveSpeed = speed;
		speed = 0;
	}

	public void slowSpeed(float decrease)
	{
		decreasedSpeed.Push(speed);
		speed = speed/decrease;
	}
	/// <summary>
	/// Resets the speed.
	/// </summary>
	public void resetSpeed()
	{
		speed = decreasedSpeed.Pop();
	}
}
