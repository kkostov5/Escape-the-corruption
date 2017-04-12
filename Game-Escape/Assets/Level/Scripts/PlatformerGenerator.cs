using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerGenerator : MonoBehaviour {

	public Transform generationPoint;

	private float distanceBetween;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private float platformWidth;
	private float oldWidth;
	public ObjectPooler tilePool;

	public ObjectPooler coinPool;
	public int randomCoinThreshold;

	public ObjectPooler spikePool; // spike generation
	public float randomSpikeThreshold;

	// Use this for initialization
	void Start () {

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) 
		{
			distanceBetween = Random.Range (distanceBetweenMin,distanceBetweenMax);

			platformWidth = Random.Range (2,9);
			bool coinCheck = false;
			bool spikeCheck = false;
			heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);
			heightChange = Mathf.Clamp(heightChange, minHeight, maxHeight);

			for (int i = 1; i <= platformWidth; i++) 
			{
				GameObject newPlatform = tilePool.getObject ();
				if(i==1)transform.position = new Vector3 (transform.position.x + 0.99f + distanceBetween, heightChange, transform.position.z);
				else transform.position = new Vector3 (transform.position.x + 1f, heightChange, transform.position.z);
				newPlatform.transform.position = transform.position;
				newPlatform.transform.rotation = transform.rotation;
				newPlatform.SetActive (true);
				if (Random.Range (0f, 100f) < randomCoinThreshold && !coinCheck) 
				{
					GameObject coin = coinPool.getObject ();
					Vector3 coinPosition = new Vector3 (0f, 1.5f, 0f);
					coin.transform.position = transform.position+coinPosition;
					coin.SetActive (true);
					coinCheck = true;

				}
				if (Random.Range (0f, 100f) < randomSpikeThreshold && !spikeCheck) 
				{
					GameObject spike = spikePool.getObject ();
					Vector3 spikePosition = new Vector3 (0f, spike.GetComponent<BoxCollider2D>().size.y/2, 0f);
					spike.transform.position = transform.position+spikePosition;
					spike.SetActive (true);
					spikeCheck = true;
				}
				oldWidth = 0.5f;
			}
		}
	}
}
