using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour, Observable {


	public void Notify(Object o ,string change)
	{
		for(int i=0;i < Application.observers.Count;i++)
		{
			Application.observers [i].update (o,change);
		}
	}
	public void AddObserver(Object a)
	{
		//GameObject[] controllers = GameObject.Find ("Controller").transform.GetChild;
		//foreach(GameObject b in controllers )
	//	{
		//	Debug.Log(b.name);
		//	Application.observers.Add (b);
		//}
		//observers.Add ();
	}

	public void RemoveObserver (Object a)
	{
		//Application.observers.Remove(a);
	}
		
}
