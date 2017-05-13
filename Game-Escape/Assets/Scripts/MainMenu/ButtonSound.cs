using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {

	public AudioClip sound;
	public AudioSource source;
	private  Button button;
	// Use this for initialization
	void Start () {
		source.clip = sound;
		button = GetComponent<Button>();
		button.onClick.AddListener(() => PlaySound());

	}

	void PlaySound()
	{
		source.PlayOneShot (sound);
	}
}
