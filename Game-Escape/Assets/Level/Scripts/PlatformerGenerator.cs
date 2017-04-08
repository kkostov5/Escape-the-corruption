using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public ObjectPooler pool;

	// Use this for initialization
	void Start () {
		platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) 
		{
			distanceBetween = Random.Range (distanceBetweenMin,distanceBetweenMax);

			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
			GameObject newPlatform = pool.getObject ();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
		}
	}
}
