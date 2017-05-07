using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTransition : MonoBehaviour {

	public Sprite[] sprites;
	public GameObject nextButton;
	public GameObject previousButton;
	private int iteration;
	private Image image;
	// Use this for initialization
	void Start () {
		iteration = 0;
		image = gameObject.GetComponent<Image> ();
		image.sprite = sprites[iteration];
	}

	public void next()
	{
		if (iteration == 0) {
			previousButton.GetComponent<Image> ().enabled = true;
			previousButton.GetComponent<Button> ().enabled = true;
		}
		iteration++;
		image.sprite = sprites[iteration];
		if (iteration == sprites.Length - 1) 
		{
			nextButton.GetComponent<Image> ().enabled = false;
			nextButton.GetComponent<Button> ().enabled = false;
		}
	}
	public void previous()
	{
		if (iteration == sprites.Length - 1)
		{
			nextButton.GetComponent<Image> ().enabled = true;
			nextButton.GetComponent<Button> ().enabled = true;
		}
		iteration--;
		image.sprite = sprites[iteration];
		if (iteration == 0)
		{
			previousButton.GetComponent<Image> ().enabled = false;
			previousButton.GetComponent<Button> ().enabled = false;
		}
	}
}
