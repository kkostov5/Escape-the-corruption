using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckView : Observable {

	public LayerMask ground;

	void Update () {
		
		if (Physics2D.OverlapCircle (gameObject.transform.position, 0.1f, ground)) 
		{
			Notify (gameObject.transform.parent.gameObject, "Grounded");
		} 
		else 
		{
			Notify (gameObject.transform.parent.gameObject, "NotGrounded");
		}
	}
}
