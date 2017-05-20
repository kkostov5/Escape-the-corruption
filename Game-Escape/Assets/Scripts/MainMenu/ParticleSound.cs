using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSound : MonoBehaviour {



	private AudioSource sound;
	private int numberOfParticles;
	private ParticleSystem system;

	// Use this for initialization
	void Start () {
		
		system = GetComponent<ParticleSystem> ();
		sound = GetComponent<AudioSource> ();
		numberOfParticles = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (!sound.clip){ return; }
		int count = system.particleCount;
		if (count > numberOfParticles){ //particle has been born
			sound.Play(); 
		}
		numberOfParticles = count; 
//		if (system.emission.) 
//		{
//			sound.PlayOneShot(sound.clip);
//		}
	}
}
