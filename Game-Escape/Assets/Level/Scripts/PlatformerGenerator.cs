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


	private CoinGenerator coinGenerator; // coin generation
	public int randomCoinThreshold;

	public ObjectPooler spikePool; // spike generation
	public float randomSpikeThreshold;

	// Use this for initialization
	void Start () {

		oldWidth = (platform.GetComponent<BoxCollider2D> ().size.x)/2;

		platformWidths = new float[pools.Length];
		for (int i = 0; i < pools.Length; i++) 
		{
			platformWidths[i] = pools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;	
		}
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;


		coinGenerator = FindObjectOfType<CoinGenerator> (); // coin generation
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

			if (Random.Range (0f, 100f) < randomCoinThreshold) 
			{
				coinGenerator.SpawnCoins (new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z));
			}

			if (Random.Range (0f, 100f) < randomSpikeThreshold) 
			{
				GameObject spike = spikePool.getObject ();

				float spikeXPosition = Random.Range (-platformWidths[selectedPlatform]/2 +1f,platformWidths[selectedPlatform]/2 -1f);

				Vector3 spikePosition = new Vector3 (spikeXPosition, 0.5f, 0f);

				spike.transform.position = transform.position+spikePosition;
				spike.transform.rotation = transform.rotation;
				spike.SetActive (true);
			}

			oldWidth = platformWidths [selectedPlatform] / 2;
		}
	}
}
