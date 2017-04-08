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

	private float oldWidth;
	public ObjectPooler[] pools;

	//public GameObject[] platforms;
	private int selectedPlatform;
	private float[] platformWidths;


	// Use this for initialization
	void Start () {

		oldWidth = 4.5f;
		platformWidth = platform.GetComponent<BoxCollider2D> ().size.x;	

		platformWidths = new float[pools.Length];
		for (int i = 0; i < pools.Length; i++) 
		{
			platformWidths[i] = pools[i].platform.GetComponent<BoxCollider2D> ().size.x;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) 
		{
			distanceBetween = Random.Range (distanceBetweenMin,distanceBetweenMax);



			selectedPlatform = Random.Range (0,pools.Length);

			platformWidth = platformWidths [selectedPlatform];

			transform.position = new Vector3 (transform.position.x + (platformWidths[selectedPlatform]/2) + oldWidth + distanceBetween, transform.position.y, transform.position.z);

			//Instantiate (pools[selectedPlatform],transform.position,transform.rotation);

			GameObject newPlatform = pools[selectedPlatform].getObject ();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			oldWidth = platformWidths [selectedPlatform] / 2;
		}
	}
}
