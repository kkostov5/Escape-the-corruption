using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Inteface for the Observer objects.
/// </summary>
public interface Observer {
	void Operation (Object o, string operation, params object[] data);
}
