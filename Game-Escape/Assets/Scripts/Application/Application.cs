using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour{

	public static List<Observer> observers;

	void Start()
	{
		observers = new List<Observer>();
		Observer[] controllers = GameObject.Find ("Controller").GetComponentsInChildren<Observer>();
		Debug.Log(controllers.Length);
		foreach(Observer b in controllers )
		{
			if(b!=null)
			{
				observers.Add (b);
			}
		}
	}
} 
