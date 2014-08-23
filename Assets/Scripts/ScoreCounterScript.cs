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
		if(!PlayerPrefs.HasKey ("best_score"))
		{
			PlayerPrefs.SetInt ("best_score", 0);
		}

		else if(!PlayerPrefs.HasKey("total_score"))
		{
			PlayerPrefs.SetInt ("total_score", 0);
		}

		best_score = PlayerPrefs.GetInt ("best_score");
		total_score = PlayerPrefs.GetInt ("total_score");
	
		total_score += current_score;
		//PlayerPrefs.SetInt("Player Score", 10);

		holder = GameObject.Find ("playership");
	}
	
	// Update is called once per frame
	void Update () {

		if (current_score > best_score) {
			best_score = current_score;		
		}

		scoreKeeper.text = "Score: " + current_score.ToString () + " " + total_score.ToString() + " " + best_score.ToString ();
		scoreKeeper.fontSize = fontSize;

		PlayerPrefs.SetInt ("best_score", best_score);
		PlayerPrefs.SetInt ("total_score", total_score);
	}
}
