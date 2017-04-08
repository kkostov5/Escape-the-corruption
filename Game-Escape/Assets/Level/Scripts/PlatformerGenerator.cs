using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerGenerator : MonoBehaviour {

	public GameObject platform;
	public Transform generationPoint;
	public float distanceBetween;


	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private float oldWidth;
	public ObjectPooler[] pools;

	private int selectedPlatform;
	private float[] platformWidths;

	// Use this for initialization
	void Start () {

		oldWidth = (platform.GetComponent<BoxCollider2D> ().size.x)/2;

		platformWidths = new float[pools.Length];
		for (int i = 0; i < pools.Length; i++) 
		{
			platformWidths[i] = pools[i].platform.GetComponent<BoxCollider2D> ().size.x;	
		}
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) 
		{
			distanceBetween = Random.Range (distanceBetweenMin,distanceBetweenMax);

			selectedPlatform = Random.Range (0,pools.Length);

			heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);

			heightChange = Mathf.Clamp(heightChange, minHeight, maxHeight);

			transform.position = new Vector3 (transform.position.x + (platformWidths[selectedPlatform]/2) + oldWidth + distanceBetween, heightChange, transform.position.z);


			GameObject newPlatform = pools[selectedPlatform].getObject ();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			oldWidth = platformWidths [selectedPlatform] / 2;
		}
	}
}
