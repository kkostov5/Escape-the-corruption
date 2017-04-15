using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, Observer {

	public GameModel model;

	public void update(Object o, string args)
	{
		if (args == "Generate Platform") 
		{
			GameObject obj = (GameObject)o;
			float distanceBetween = Random.Range (model.platformDistanceMin, model.platformDistanceMax);
			float platformWidth = Random.Range (2, 9);
			bool coinCheck = false;
			bool spikeCheck = false;
			float platformHeightChange = obj.transform.position.y + Random.Range (model.platformHeightDifference, -model.platformHeightDifference);
			platformHeightChange = Mathf.Clamp (platformHeightChange, model.platformHeightMin, model.platformHeightMax);

			for (int i = 1; i <= platformWidth; i++) {
				GameObject newPlatform = model.tilePooler.getObject ();
				if (i == 1)
					obj.transform.position = new Vector3 (obj.transform.position.x + 0.99f + distanceBetween, platformHeightChange, obj.transform.position.z);
				else
					obj.transform.position = new Vector3 (obj.transform.position.x + 1f, platformHeightChange, obj.transform.position.z);
				newPlatform.transform.position = obj.transform.position;
				newPlatform.transform.rotation = obj.transform.rotation;
				newPlatform.SetActive (true);
				if (Random.Range (0f, 100f) < model.coinRate && !coinCheck) {
					GameObject coin = model.coinPooler.getObject ();
					Vector3 coinPosition = new Vector3 (0f, 1.5f, 0f);
					coin.transform.position = obj.transform.position + coinPosition;
					coin.SetActive (true);
					coinCheck = true;

				}
				if (Random.Range (0f, 100f) < model.dangerRate && !spikeCheck) {
					GameObject spike = model.spikePooler.getObject ();
					Vector3 spikePosition = new Vector3 (0f, spike.GetComponent<BoxCollider2D> ().size.y / 2, 0f);
					spike.transform.position = obj.transform.position + spikePosition;
					spike.SetActive (true);
					spikeCheck = true;
				}
			}
		}
	}
	

	void Update()
	{
		GameObject[] tiles = GameObject.FindGameObjectsWithTag ("Ground");
		Debug.Log (tiles.Length);
		foreach (GameObject obj in tiles) 
		{
			Debug.Log ("HHHHH");
			//obj.transform.position = new Vector2 (obj.transform.position.x-0.3f,obj.transform.position.y);
			//obj.GetComponent<Speed> ().speed = 1f;
			Speed blaj = (Speed)obj.GetComponent(typeof(Speed));
			blaj.UpdateSpeed (model.speed);
		}
	}
		
}
