using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform {

	private float maxDistance;
	private float minDistance;
	private float maxHeight;
	private float heightDifference;
	private float minHeight;
	private float maxWidth;
	private float minWidth;

	public Platform(float maxDistance,float minDistance,float maxHeight ,float heightDifference, float minHeight,float maxWidth,float minWidth )
	{
		this.maxDistance = maxDistance;
		this.minDistance = minDistance;
		this.maxHeight = maxHeight;
		this.heightDifference = heightDifference;
		this.minHeight = minHeight;
		this.maxWidth = maxWidth;
		this.minWidth = minWidth;
	}

	public float MaxDistance { get { return maxDistance; } set { maxDistance = value; } }
	public float MinDistance {get {return minDistance;}set {minDistance = value;}}
	public float MaxHeight {get {return maxHeight;}set {maxHeight = value;}}
	public float MinHeight {get {return minHeight;}set {minHeight = value;}}
	public float MaxWidth {get {return maxWidth;}set {maxWidth = value;}}
	public float MinWidth {get {return minWidth;}set {minWidth = value;}}

	public float getPlatformWidth()
	{
		float range = Random.Range (minWidth, maxWidth);
		return range;
	}

	public float getPlatformHeight(float lastHeight)
	{
		float height = lastHeight + Random.Range(-heightDifference,heightDifference);
		height = Mathf.Clamp(height, minHeight, maxHeight);
		return height;
	}

	public float getPlatformDistance()
	{
		float range = Random.Range (minDistance, maxDistance);
		return range;
	}

}
