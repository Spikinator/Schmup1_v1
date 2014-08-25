using UnityEngine;
using System.Collections;

public class ScoreCounterScript : MonoBehaviour {

	public static int current_score;

	public static int total_score;
	public static int best_score;

	public static int highest_level;

	public static int cash;

	public GUIText scoreKeeper;
	public GUIText cashTracker;

	private GameObject holder;

	public int fontSize = 24;


	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("cash")) {
			PlayerPrefs.SetInt("cash", 0);		
		}

		if (!PlayerPrefs.HasKey ("highest_level")) {
			PlayerPrefs.SetInt("highest_level", 0);		
		}

		if(!PlayerPrefs.HasKey ("best_score"))
		{
			PlayerPrefs.SetInt ("best_score", 0);
		}



		else if(!PlayerPrefs.HasKey("total_score"))
		{
			PlayerPrefs.SetInt ("total_score", 0);
		}

		total_score += current_score;

		highest_level = PlayerPrefs.GetInt ("highest_level");

		cash = PlayerPrefs.GetInt ("cash");

		best_score = PlayerPrefs.GetInt ("best_score");
		total_score = PlayerPrefs.GetInt ("total_score");
	

		//PlayerPrefs.SetInt("Player Score", 10);

		holder = GameObject.Find ("playership");
	}
	
	// Update is called once per frame
	void Update () {

		if (current_score > best_score) {
			best_score = current_score;		
		}



		scoreKeeper.text = "Score: " + current_score.ToString ();
		scoreKeeper.fontSize = fontSize;

		cashTracker.text = "Cash: $" + cash;
		cashTracker.fontSize = fontSize;

		PlayerPrefs.SetInt ("best_score", best_score);
		PlayerPrefs.SetInt ("total_score", total_score);
		PlayerPrefs.SetInt ("cash", cash);
		PlayerPrefs.SetInt ("highest_level", highest_level);
	}
}
