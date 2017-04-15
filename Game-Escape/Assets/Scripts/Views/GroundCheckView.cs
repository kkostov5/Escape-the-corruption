using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckView : View {

	public LayerMask ground;

	void Update () {
		if (Physics2D.OverlapCircle (gameObject.transform.position, 0.1f, ground)) {
			Debug.Log ("GroundShit");
			Notify (gameObject, "Grounded");
		} else {
			Notify (gameObject, "NotGrounded");
		}
	}
}
