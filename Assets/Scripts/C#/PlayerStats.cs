using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public GUIText total_score;
	public GUIText level;
	public GUIText cash;
	public GUIText current_score;
	public GUIText best_score;

	// Use this for initialization
	void Start () {
		total_score.text = "" + PlayerPrefs.GetInt ("total_score");
		Debug.Log(" " + PlayerPrefs.GetInt("total_score"));
		level.text = "" + PlayerPrefs.GetInt ("highest_level");
		cash.text = "" + PlayerPrefs.GetInt ("cash");
		current_score.text = "" + ScoreCounterScript.current_score;
		best_score.text = "" + PlayerPrefs.GetInt ("best_score");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
