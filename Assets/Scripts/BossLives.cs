using UnityEngine;
using System.Collections;

public class BossLives : MonoBehaviour {
	
	private Animator animator;
	public GameObject holder;
	public int health;
	
	public void Start() {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (holder != null) {

			holder = GameObject.Find ("boss");
			HealthScript healthScript = holder.GetComponent<HealthScript>();
			health = healthScript.hp;
			
			animator.SetInteger("Health", health);
		}
		
		else if(holder == null) 
		{
			animator.SetInteger ("Health", 0);
		}
		
		
	}
}
