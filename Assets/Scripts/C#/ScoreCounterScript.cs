using UnityEngine;
using System.Collections;

public class ScoreCounterScript : MonoBehaviour {

	public static int current_score;

	public static int total_score;
	public static int best_score;

	public static int highest_level;

	public static int cash;

	public static int unlocked;

	public static int enemy_count;

	public GUIText scoreKeeper;
	public GUIText cashTracker;

	private GameObject holder;

	public int fontSize = 24;


	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("unlocked")) {
			PlayerPrefs.SetInt("unlocked", 0);		
		}

		if (!PlayerPrefs.HasKey ("enemy_count")) {
			PlayerPrefs.SetInt("enemy_count", 0);		
		}

		if (!PlayerPrefs.HasKey ("cash")) {
			PlayerPrefs.SetInt("cash", 0);		
		}

		if (!PlayerPrefs.HasKey ("highest_level")) {
			PlayerPrefs.SetInt("highest_level", 0);		
		}

		if(!PlayerPrefs.HasKey ("best_score")) {
			PlayerPrefs.SetInt ("best_score", 0);
		}


		else if(!PlayerPrefs.HasKey("total_score"))
		{
			PlayerPrefs.SetInt ("total_score", 0);
		}
		enemy_count = PlayerPrefs.GetInt ("enemy_count");

		unlocked = PlayerPrefs.GetInt ("unlocked");

		highest_level = PlayerPrefs.GetInt ("highest_level");

		cash = PlayerPrefs.GetInt ("cash");

		best_score = PlayerPrefs.GetInt ("best_score");
		total_score = PlayerPrefs.GetInt ("total_score");

		holder = GameObject.Find ("playership");
	}
	
	// Update is called once per frame
	void Update () {

		if (current_score > best_score) {
			best_score = current_score;		
		}

		unlocked = highest_level + 1;

		scoreKeeper.text = "Score: " + current_score.ToString ();
		scoreKeeper.fontSize = fontSize;

		cashTracker.text = "Cash: $" + cash;
		cashTracker.fontSize = fontSize;

		PlayerPrefs.SetInt ("enemy_count", enemy_count);
		PlayerPrefs.SetInt ("unlocked", unlocked);
		PlayerPrefs.SetInt ("best_score", best_score);
		PlayerPrefs.SetInt ("total_score", total_score);
		PlayerPrefs.SetInt ("cash", cash);
		PlayerPrefs.SetInt ("highest_level", highest_level);
	}
}
