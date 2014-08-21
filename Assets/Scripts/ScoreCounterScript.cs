using UnityEngine;
using System.Collections;

public class ScoreCounterScript : MonoBehaviour {

	public static int score = 0;
	public GUIText scoreKeeper;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		scoreKeeper.text = "Score: " + score.ToString ();
	}
}
