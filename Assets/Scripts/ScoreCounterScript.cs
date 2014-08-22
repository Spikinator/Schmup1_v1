using UnityEngine;
using System.Collections;

public class ScoreCounterScript : MonoBehaviour {

	public static int score = 0;
	public GUIText scoreKeeper;

	private GameObject holder;

	public int fontSize = 24;


	// Use this for initialization
	void Start () {
		holder = GameObject.Find ("playership");
	}
	
	// Update is called once per frame
	void Update () {

		scoreKeeper.text = "Score: " + score.ToString ();
		scoreKeeper.fontSize = fontSize;
	}
}
