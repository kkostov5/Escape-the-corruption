using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour,Observer {


	public void update(Object o, string args)
	{
		GameObject obj = (GameObject) o;
		if (args == "Jump") 
		{
			obj.GetComponent<Animator> ().SetBool ("Speed", false);
			obj.GetComponent<Animator>().SetBool("Ground",false);
		}
		else if (args == "Grounded") 
		{
			obj.GetComponent<Animator>().SetBool("Ground",true);
			obj.GetComponent<Animator> ().SetBool ("Speed", true);

		}
		else if (args == "NotGrounded") 
		{
			obj.GetComponent<Animator> ().SetBool ("Speed", false);
			obj.GetComponent<Animator>().SetBool("Ground",false);
		}
	}
		
}
