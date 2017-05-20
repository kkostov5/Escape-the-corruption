using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterTransition : MonoBehaviour {
	/// <summary>
	/// Characters.
	/// </summary>
	[System.Serializable]
	public struct Characters
	{
		public Sprite[] characterSprites;
		public RuntimeAnimatorController[] anims;
		public float scoreRequired;
	}

	public Characters[] characters;

	public GameObject colorPanel;
	public GameObject nextButton;
	public GameObject previousButton;
	public GameObject startButton;

	public Text NotAccessible;

	private int characterIndex;
	private int versionIndex;
	private Image image;

	// Use this for initialization
	void Start () {
		characterIndex = 0;
		versionIndex = 0;
		image = gameObject.GetComponent<Image> ();
		previousButton.GetComponent<Button> ().interactable = false;
		image.sprite = characters[characterIndex].characterSprites[versionIndex];
		//PlayerPrefs.SetFloat ("HighScore", 0f);
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update()
	{
		image.sprite = characters [characterIndex].characterSprites [versionIndex];
	}



	/// <summary>
	/// Next the character.
	/// </summary>
	public void NextCharacter()
	{
		if (characterIndex == 0) {
			previousButton.GetComponent<Button> ().interactable = true;
		}
		characterIndex++;
		Transition ();
	}
	/// <summary>
	/// Previous the character.
	/// </summary>
	public void PreviousCharacter()
	{
		if (characterIndex == characters.Length - 1)
		{
			nextButton.GetComponent<Button> ().interactable = true;
		}
		characterIndex--;
		Transition ();
	}
	/// <summary>
	/// Transition this instance.
	/// </summary>
	public void Transition()
	{
		versionIndex = 0;
		if (characters [characterIndex].scoreRequired > PlayerPrefs.GetFloat ("HighScore")) {
			NotAccessible.text = "You need highscore of " + characters [characterIndex].scoreRequired + " to unlock the character.";
			NotAccessible.gameObject.SetActive (true);
			startButton.SetActive (false);
		} else {
			NotAccessible.gameObject.SetActive (false);
			startButton.SetActive (true);
		}
		// Hides/Shows buttons if it is the last or first character
		if (characterIndex == 0) 
		{
			previousButton.GetComponent<Button> ().interactable = false;
		} else if (characterIndex == characters.Length - 1)
		{
			nextButton.GetComponent<Button> ().interactable = false;
		}

		 //Hides/Shows the colorPanel if there are no other colors;
		if (characters [characterIndex].characterSprites.Length == 1)
		{
			colorPanel.GetComponent<CanvasGroup> ().alpha = 0f;
			colorPanel.GetComponent<CanvasGroup> ().blocksRaycasts = false;
		}
		else {
			colorPanel.GetComponent<CanvasGroup> ().alpha = 1f;
			colorPanel.GetComponent<CanvasGroup> ().blocksRaycasts = true;
		}
	}
	/// <summary>
	/// Changes the color.
	/// </summary>
	/// <param name="color">Color.</param>
	public void changeColor(string color)
	{
		switch (color) {
		case "blue":
			versionIndex = 0;
			break;
		case "yellow":
			versionIndex = 1;
			break;
		case "grey":
			versionIndex = 2;
			break;
		case "pink":
			versionIndex = 3;
			break;
		case "red":
			versionIndex = 4;
			break;
		default:
			break;
		}
	
	}

	/// <summary>
	/// Back to Main Menu.
	/// </summary>
	public void Back()
	{
		SceneManager.LoadScene("Menu");
	}

	/// <summary>
	/// Starts the level.
	/// </summary>
	public void StartLevel()
	{
		
		Character.SetAnim (characters [characterIndex].anims [versionIndex]);
		Character.SetSprite (characters [characterIndex].characterSprites [versionIndex]);
		SceneManager.LoadScene("LevelScene");
	}
}

