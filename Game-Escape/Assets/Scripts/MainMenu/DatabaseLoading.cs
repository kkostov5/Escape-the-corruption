using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Security.Cryptography;

public class DatabaseLoading : MonoBehaviour {

	public GameObject EntryPrefab;
	private string[] items;
	public float position;


	IEnumerator Start(){
		WWW data = new WWW("https://zeno.computing.dundee.ac.uk/2016-ac32006/krasimirkostov/Scoreboard.php");
		yield return data;
		string dataStrings = data.text;
		print (dataStrings);
		items = dataStrings.Split(';');
		GetDataValue(items);
	}

	/// <summary>
	/// Gets the data value.
	/// </summary>
	/// <param name="data">Data.</param>
	void GetDataValue(string[] data){
		string catergoryName = "Name:";
		string catergoryScore = "Score:";
		string name;
		string score;
		for (int i = 0; i < data.Length-1; i++) 
		{
			name = data[i].Substring (data[i].IndexOf (catergoryName) + catergoryName.Length);
			score = data[i].Substring (data[i].IndexOf (catergoryScore) + catergoryScore.Length);
			if (score.Contains ("|"))score = score.Remove (score.IndexOf ("|"));
			if (name.Contains ("|"))name =  name.Remove (name.IndexOf ("|"));
			PresentEntry (i+1, name, score);
		}
}

	/// <summary>
	/// Presents the entry.
	/// </summary>
	/// <param name="position">Position.</param>
	/// <param name="name">Name.</param>
	/// <param name="score">Score.</param>
	void PresentEntry(int position,string name, string score)
	{
		GameObject obj = (GameObject)Instantiate (EntryPrefab);
		obj.transform.SetParent (gameObject.transform,false);
		obj.transform.FindChild ("Position").GetComponent<Text> ().text = position.ToString();
		obj.transform.FindChild ("Username").GetComponent<Text> ().text = name;
		obj.transform.FindChild ("Score").GetComponent<Text> ().text = score;
	}

}
