using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,Observer {

	public PlayerModel model;

	public void Operation(Object o, string operation)
	{
		if (operation == "Jump") 
		{
			GameObject obj = (GameObject) o;

			if (model.ground) 
			{
				Jump (obj);
			}
			if (!model.ground && model.doubleJump) 
			{
				Jump (obj);
				model.jumpTimer = model.jumpTime;
				model.doubleJump = false;
			}
		}
		else if(operation == "Longer Jump")
		{
			GameObject obj = (GameObject) o;
			if (model.jumpTimer>0)
			{
				Jump (obj);
				model.jumpTimer -= Time.deltaTime;
			}
		}
		else if(operation == "End Jump"){
			model.jumpTimer = 0;
		}
		else if (operation == "Grounded") 
		{
			model.ground = true;
			model.jumpTimer = model.jumpTime;
			model.doubleJump = true;
		}
		else if (operation == "NotGrounded") 
		{
			model.ground = false;
		}
		else if (operation == "Death") 
		{
			model.ground = false;
		}
	}
	void Start()
	{
		model = new PlayerModel ();
	}
	/// <summary>
	/// Jump the specified obj.
	/// </summary>
	/// <param name="obj">Object.</param>
	void Jump(GameObject obj)
	{
		obj.GetComponent<Rigidbody2D>().velocity = new Vector2 (obj.GetComponent<Rigidbody2D>().velocity.x, model.jumpPower);
	}
}
