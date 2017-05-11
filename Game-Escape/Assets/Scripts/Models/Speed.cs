using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Speed  {

	private static float speed;
	private float speedMultiplier;
	private float speedTarget;
	private float speedRatio;
	private float saveSpeed;
	private float time ;

	public Speed(float speed,float speedMultiplier,float speedTarget)
	{
		Speed.speed = speed;
		this.speedMultiplier = speedMultiplier;
		this.speedTarget = speedTarget;
		speedRatio = speedTarget;
		time = 0;
		saveSpeed = 0;
	}

	public static float getSpeed(){ return Speed.speed;}
	public float SpeedValue {get {return speed;}set {speed = value;}}
	public float SpeedMultiplier {get {return speedMultiplier;}set { speedMultiplier = value; }}

	/// <summary>
	/// Updates the speed.
	/// </summary>
	/// <param name="time">Time.</param>
	public bool updateSpeed(float timeUpdate)
	{
		time += timeUpdate;
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

	/// <summary>
	/// Resets the speed.
	/// </summary>
	public void resetSpeed()
	{
		speed = saveSpeed;
	}
}
