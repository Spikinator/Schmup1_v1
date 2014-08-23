using UnityEngine;
using System.Collections;

public class ScoreCounterScript : MonoBehaviour {

	public static int current_score;

	public static int total_score;
	public static int best_score;

	public GUIText scoreKeeper;

	private GameObject holder;

	public int fontSize = 24;


	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("current_score") == null) {
			current_score = 0;
		}

		PlayerPrefs.SetInt("Player Score", 10);

		holder = GameObject.Find ("playership");

		if (total_score == null) {
			total_score = 0;
		}
		total_score += current_score;
	}
	
	// Update is called once per frame
	void Update () {

		if (best_score == null) {
			best_score = 0;		
		}

		if (current_score > best_score) {
			best_score = current_score;		
		}

		scoreKeeper.text = "Score: " + current_score.ToString () + " " + total_score.ToString() + " " + best_score.ToString ();
		scoreKeeper.fontSize = fontSize;
	}
}
