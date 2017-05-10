using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player model.
/// </summary>
public class PlayerModel
{
	private float _jumpPower = 10f;
	private float _jumpTime = 0.5f;
	private float _jumpTimer = 0.5f;
	private bool _doubleJump;
	private bool _ground;


	public float jumpPower { get { return _jumpPower; }set{ _jumpPower = value;}}
	public float jumpTime { get { return _jumpTime; }set{ _jumpTime = value;}}
	public float jumpTimer { get { return _jumpTimer; }set{ _jumpTimer = value;}}
	public bool ground { get { return _ground; }set{ _ground = value;}}
	public bool doubleJump { get { return _doubleJump; }set{ _doubleJump = value;}}
		
}
