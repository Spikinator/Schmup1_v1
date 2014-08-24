using UnityEngine;
using System.Collections;

public class ClickToIntro : MonoBehaviour {

	private bool enter;
	
	void Start()
	{
		
	}
	
	void Update()
	{
		enter = Input.GetKeyDown (KeyCode.Return);
		if (enter) {
			Application.LoadLevel("TypeWriteTestScene"); // load the level!!!!!!
		}
	}
}
