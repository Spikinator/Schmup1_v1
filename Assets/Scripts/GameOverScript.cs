using UnityEngine;
using System.Collections;


public class GameOverScript : MonoBehaviour {
	void Start()
	{
		StartCoroutine(Delay());
	}

	void Update()
	{

	}

	IEnumerator Delay()
	{
		yield return new WaitForSeconds (2.0f);
		if (Application.loadedLevelName == "Stage1") {
			Application.LoadLevel ("LoseScene");
		} else if (Application.loadedLevelName == "Stage2") {
			Application.LoadLevel ("LoseScene2");
		}

	}

}