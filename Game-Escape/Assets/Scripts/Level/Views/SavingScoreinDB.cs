using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavingScoreinDB : Observable {

	private InputField inputField;
	public Button saveButton;
	// Use this for initialization
	void Start () {
		inputField = GetComponent<InputField> ();
	}

	// Update is called once per frame
	void Update () {
		if (!string.IsNullOrEmpty(inputField.text) && isNotWhiteSpaces(inputField.text)) {
			saveButton.interactable = true;	
		}
		else saveButton.interactable = false;	
	}

	public void saveScore()
	{
		Notify (null,"SaveScore",inputField.text);
	}

	bool isNotWhiteSpaces(string input) 
	{
		foreach(char letter in input){
			if(letter != ' ') return true;
		}
		return false;
	}

}
