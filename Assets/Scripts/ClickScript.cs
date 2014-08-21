using UnityEngine;
using System.Collections;

public class ClickScript : MonoBehaviour {

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

	/*private Animator animator;

	void OnMouseOver()
	{
		animator = this.GetComponent<Animator> ();
		animator.SetInteger("Focus", 1);
		Debug.Log ("you moused over");
	}
	
	void OnMouseExit()
	{
		animator = this.GetComponent<Animator> ();
		animator.SetInteger ("Focus", 0);
	}
	
	void OnMouseDown()
	{
		animator = this.GetComponent<Animator> ();
		animator.SetInteger ("Focus", 2);
		Application.LoadLevel("Stage1"); // "Stage1" is the scene name
	}

	// Update is called once per frame
	/* void Update () {



		if(Input.GetMouseButtonDown(0))
		{
			animator.SetInteger ("Focus", 2);

		}

	} */
}
