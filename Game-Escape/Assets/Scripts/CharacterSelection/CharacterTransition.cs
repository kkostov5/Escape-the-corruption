using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTransition : MonoBehaviour {

	[System.Serializable]
	public struct Characters
	{
		public Sprite[] colors;
	}
	public GameObject colorPanel;
	public Characters[] sprites;
	public GameObject nextButton;
	public GameObject previousButton;
	private int iteration;
	private Image image;
	// Use this for initialization
	void Start () {
		iteration = 0;
		image = gameObject.GetComponent<Image> ();
		previousButton.GetComponent<Button> ().interactable = false;
		image.sprite = sprites[iteration].colors[0];
	}

	public void next()
	{
		if (iteration == 0) {
			previousButton.GetComponent<Button> ().interactable = true;
		}
		iteration++;
		transition ();
	}

	public void previous()
	{
		if (iteration == sprites.Length - 1)
		{
			nextButton.GetComponent<Button> ().interactable = true;
		}
		iteration--;
		transition ();
	}
	public void transition()
	{
		image.sprite = sprites[iteration].colors[0];
		if (iteration == 0) {
			previousButton.GetComponent<Button> ().interactable = false;
		} else if (iteration == sprites.Length - 1)
		{
			nextButton.GetComponent<Button> ().interactable = false;
		}
		if (sprites [iteration].colors.Length == 1)
		{
			colorPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			colorPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
		else {
			colorPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			colorPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}
	public void changeColor(string color)
	{
		if (color == "blue") image.sprite = sprites[iteration].colors[0];
		else if(color=="yellow") image.sprite = sprites[iteration].colors[1];
		else if(color=="grey") image.sprite = sprites[iteration].colors[2];
		else if(color=="pink") image.sprite = sprites[iteration].colors[3];
		else if(color=="red") image.sprite = sprites[iteration].colors[4];
	}
}

