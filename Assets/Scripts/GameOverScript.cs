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
		Application.LoadLevel("LoseScene");
	}

}