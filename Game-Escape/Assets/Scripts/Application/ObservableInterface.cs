using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for the Observable objects.
/// </summary>
public interface ObservableInterface {
	
	void Notify(Object obj, string change);

}
