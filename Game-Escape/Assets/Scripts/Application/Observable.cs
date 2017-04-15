using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Observable {


	void Notify(Object o, string change);
	//void AddObserver(Object a);
	//void RemoveObserver (Object a);
}
