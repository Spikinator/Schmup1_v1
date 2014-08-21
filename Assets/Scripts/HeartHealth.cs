using UnityEngine;
using System.Collections;

public class HeartHealth : MonoBehaviour {

	private Animator animator;
	public GameObject holder;
	public int health;

	public void Start() {
		animator = this.GetComponent<Animator> ();
	}
		
	// Update is called once per frame
	void Update () {

		holder = GameObject.Find ("playership");
		HealthScript healthScript = holder.GetComponent<HealthScript>();
		health = healthScript.hp;

		animator.SetInteger("Health", health);

		if (holder == null) 
		{
			animator.SetInteger ("Health", 0);
		}


	}
}
