using UnityEngine;


public class PlayerScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(50, 50);
	private Animator animator;
	
	// 2 - Store the movement
	private Vector2 movement;

	void Start() {
		animator = this.GetComponent<Animator> ();
	}

	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		
		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);


		// 5 - Shooting
		bool shoot = Input.GetKeyDown(KeyCode.Space);
		bool noshoot = Input.GetKeyUp(KeyCode.Space);
				
		if (shoot)
		{
			animator.SetBool("Firing", true);

			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
				SoundEffectsHelper.Instance.MakePlayerShotSound();
				//animator.SetBool("Firing", false);
			}

		}

		if (noshoot) {
				animator.SetBool ("Firing", false);
		}

		// Make sure we are not outside the camera bounds
		var dist = (transform.position - Camera.main.transform.position).z;
		
		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).x;
		
		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
			).x;
		
		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
			).y;
		
		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
			).y;
		
		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
		);

		if(transform.position.x > 75) {
			ScoreCounterScript.current_score += this.GetComponent<HealthScript>().hp * 50;
			Debug.Log (ScoreCounterScript.current_score);
			Application.LoadLevel("WinScene");
		
		}
	}
	
	void FixedUpdate()
	{
		//  Move the game object
		rigidbody2D.velocity = movement;
	}
	

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;
		
		// Collision with enemy
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			// Kill the enemy
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			
			damagePlayer = true;
		}
		
		// Damage the player
		if (damagePlayer)
		{
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1);
		}
	}

	void OnDestroy()
	{
		// Game Over.
		// Add the script to the parent because the current game
		// object is likely going to be destroyed immediately.
		transform.parent.gameObject.AddComponent<GameOverScript>();
	}
}

