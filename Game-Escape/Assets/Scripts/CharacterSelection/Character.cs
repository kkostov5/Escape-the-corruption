using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Character {
	private static RuntimeAnimatorController anim; 
	private static Sprite sprite;

	public static RuntimeAnimatorController GetAnim() {  return anim; }
	public static void SetAnim(RuntimeAnimatorController value) { anim = value; }
	public static Sprite GetSprite() {  return sprite; }
	public static void SetSprite(Sprite value) { sprite = value; }

}
	