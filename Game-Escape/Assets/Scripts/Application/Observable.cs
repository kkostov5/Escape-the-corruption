using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable : MonoBehaviour, ObservableInterface {
	/// <summary>
	/// Notify the object and action.
	/// </summary>
	/// <param name="obj">Object.</param>
	/// <param name="change">Change.</param>
	public void Notify(Object obj ,string action)
	{
		for (int i = 0; i < ObserverList.observers.Count; i++) {
			ObserverList.observers [i].Operation (obj, action);
		}
	}
		
}
