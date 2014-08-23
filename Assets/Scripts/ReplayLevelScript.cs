using UnityEngine;
using System.Collections;

public class ReplayLevelScript : MonoBehaviour {

	private bool back;
	private bool menu;
	
	void Start()
	{
		
	}
	
	void Update()
	{
		back = Input.GetKeyDown (KeyCode.Backspace);
		menu = Input.GetKeyDown (KeyCode.Return);

		if (back) {
			ScoreCounterScript.current_score = 0;
			Application.LoadLevel("Stage1"); // load the level!!!!!!
		}

		if (menu) {
			Application.LoadLevel ("menu");
		}
	}
}
