using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {
	
	// Use this for initialization
	//void Start () {
	
	//}
	
	// Update is called once per frame
	//void Update () {
	
	//}
	
	public int value = 0;
	
	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.gameObject.name == "playership") {
			Destroy(this.gameObject);
			ScoreCounterScript.cash += value;
		}
	}
}
