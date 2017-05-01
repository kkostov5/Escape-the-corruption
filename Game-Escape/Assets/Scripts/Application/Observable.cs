using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observable : MonoBehaviour, ObservableInterface {

	public void Notify(Object obj ,string change)
	{
		for (int i = 0; i < Application.observers.Count; i++) {
			Application.observers [i].Operation (obj, change);
		}
	}
		
}
