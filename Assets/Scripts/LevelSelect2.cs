using UnityEngine;
using System.Collections;

public class LevelSelect2 : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown() {

		if (PlayerPrefs.GetInt ("unlocked") < 2) {
			Debug.Log ("You don't have a high enough level");
		} else {
			Application.LoadLevel ("Stage2");
		}

	}
}
