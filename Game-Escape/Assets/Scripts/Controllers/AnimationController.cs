using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour,Observer {


	public void Operation(Object o, string operation)
	{
		GameObject obj = (GameObject) o;
		if (operation == "Jump") 
		{
			obj.GetComponent<Animator> ().SetBool ("Speed", false);
			obj.GetComponent<Animator>().SetBool("Ground",false);
		}
		else if (operation == "Grounded") 
		{
			obj.GetComponent<Animator>().SetBool("Ground",true);
			obj.GetComponent<Animator> ().SetBool ("Speed", true);

		}
		else if (operation == "NotGrounded") 
		{
			obj.GetComponent<Animator> ().SetBool ("Speed", false);
			obj.GetComponent<Animator>().SetBool("Ground",false);
		}
	}
		
}
