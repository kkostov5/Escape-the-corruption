using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : View
{
	public float jumpPower = 10f;
	public float jumpTime = 0.5f;
	public float jumpTimer = 0.5f;
	public bool _doubleJump;
	public bool _ground;

	public bool ground { get; set;}
	public bool doubleJump { get; set;}
		
}
