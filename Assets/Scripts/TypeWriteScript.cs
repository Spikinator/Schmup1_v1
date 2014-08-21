using UnityEngine;
using System.Collections;

public class TypeWriteScript : MonoBehaviour {

	private bool enter;
	public float letterPause = 0.001f;
	public AudioClip sound;

	private bool isReady = true;

	public float wait;
	
	public string message;
	
	// Use this for initialization
	void Start () {


		//message = " ";
		guiText.text = "";


		StartCoroutine(TypeText ());



	}


	void Update() {
		//FormatGuiTextArea (guiText, 400);

		enter = Input.GetKeyDown (KeyCode.Return);

		if (enter) {
			Application.LoadLevel("Stage1"); // load the level!!!!!!
		}

	}
	
	IEnumerator TypeText () {
		yield return new WaitForSeconds(wait);

			foreach (char letter in message.ToCharArray()) {
				guiText.text += letter;
				if (sound)
					audio.PlayOneShot (sound);
				yield return 0;
				yield return new WaitForSeconds (letterPause);
			}   
			yield return new WaitForSeconds(wait);

		   
	}

	public static Rect FormatGuiTextArea(GUIText guiText, float maxAreaWidth)
	{

		string[] words = guiText.text.Split(' ');
		string result = "";
		Rect textArea = new Rect();
		
		for(int i = 0; i < words.Length; i++)
		{
			// set the gui text to the current string including new word
			guiText.text = (result + words[i] + " ");
			// measure it
			textArea = guiText.GetScreenRect();
			// if it didn't fit, put word onto next line, otherwise keep it
			if(textArea.width > maxAreaWidth)
			{
				result += ("\n" + words[i] + " ");
			}
			else
			{
				result = guiText.text;
			}
		}
		return textArea;
	}






}
