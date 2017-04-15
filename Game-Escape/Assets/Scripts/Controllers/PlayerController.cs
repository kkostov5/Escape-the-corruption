using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,Observer {

	public PlayerModel model;

	public void update(Object o, string args)
	{
		if (args == "Jump") 
		{
			GameObject obj = (GameObject) o;
			Debug.Log (model.ground);
			if (model.ground) 
			{
				Jump (obj);
			}
			if (!model.ground && model.canDoubleJump) 
			{
				Jump (obj);
				model.jumpTimer = model.jumpTime;
				model.canDoubleJump = false;
			}
		}
		else if (args == "Grounded") 
		{
			model.ground = true;
			model.canDoubleJump = true;
		}
		else if (args == "NotGrounded") 
		{
			model.ground = false;
		}
	}


	void Jump(GameObject obj)
	{
		Debug.Log ("Trying to jump");
		obj.GetComponent<Animator>().SetBool ("Ground", false);
		obj.GetComponent<Rigidbody2D>().velocity = new Vector2 (obj.GetComponent<Rigidbody2D>().velocity.x, model.jumpPower);
		model.endJump = false;
	}
}
