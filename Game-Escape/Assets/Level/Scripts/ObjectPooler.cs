using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;

	public int poolAmount;

	private List<GameObject> pool;

	// Use this for initialization
	void Start () {
		pool = new List<GameObject> ();
		for (int i = 0; i < poolAmount; i++) 
		{
			GameObject obj = (GameObject) Instantiate (pooledObject);
			obj.transform.parent = transform;
			obj.SetActive (false);
			pool.Add (obj);
		}
	}
	
	public GameObject getObject()
	{
		for (int i = 0; i < pool.Count; i++) 
		{
			if(!pool[i].activeInHierarchy)
			{
				return pool [i];
			}

		}

		GameObject obj = (GameObject) Instantiate (pooledObject);
		obj.SetActive (false);
		pool.Add (obj);
		return obj;
	}
}
