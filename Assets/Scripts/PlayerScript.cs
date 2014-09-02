using UnityEngine;


public class PlayerScript : MonoBehaviour
{
	private Animator animator;
	public Vector2 speed = new Vector2(50, 50);

	public bool bossDestroy = false;

	private Vector2 movement;
	//private GameObject bg_scroll;

	private ScrollingScript other; 
	private ScrollingScript bg_script;
	private ScrollingScript camera;
	private ScrollingScript stats;

	void Start() {
		bg_script = GameObject.Find("0 - Background").GetComponent<ScrollingScript>();
		camera = GameObject.Find("Main Camera").GetComponent<ScrollingScript>();
		stats = GameObject.Find("4 - PlayerStats").GetComponent<ScrollingScript>();
		other = this.gameObject.GetComponent<ScrollingScript>();
		animator = this.GetComponent<Animator> ();
		//bg_scroll = GameObject.Find ("0 - Background");
	}

	void Update()
	{
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);

		bool shoot = Input.GetKeyDown(KeyCode.Space);
		bool noshoot = Input.GetKeyUp(KeyCode.Space);
				
		if (shoot)
		{
			animator.SetBool("Firing", true);

			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				weapon.Attack(false);
				SoundEffectsHelper.Instance.MakePlayerShotSound();
			}

		}

		if (noshoot) {
				animator.SetBool ("Firing", false);
		}

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

		if(transform.position.x > 23) {

			if(Application.loadedLevelName == "Stage1")
			{
				// boss stuff
				Destroy(other);
				Destroy(bg_script);
				Destroy(camera);
				Destroy(stats);

				// winning stuff
				if(GameObject.Find ("boss") == null)
				{
					ScoreCounterScript.current_score += this.GetComponent<HealthScript>().hp * 50;

					if(PlayerPrefs.GetInt ("unlocked") > 1)
					{
						// do nothing
					}
					else{
						ScoreCounterScript.highest_level = 1;
					}
					
					
					ScoreCounterScript.total_score += ScoreCounterScript.current_score;
					Application.LoadLevel("WinScene");
				}

			}

			if(Application.loadedLevelName == "Stage2")
			{
				// boss stuff
				Destroy(other);
				Destroy(bg_script);
				Destroy(camera);
				Destroy(stats);
				
				// winning stuff
				if(GameObject.Find ("boss") == null)
				{
					ScoreCounterScript.current_score += this.GetComponent<HealthScript>().hp * 50;
					
					if(PlayerPrefs.GetInt ("unlocked") > 2)
					{
						// do nothing
					}
					else{
						ScoreCounterScript.highest_level = 2;
					}
					
					
					ScoreCounterScript.total_score += ScoreCounterScript.current_score;
					Application.LoadLevel("WinScene2");
				}


			} 

		}
	}
	
	void FixedUpdate()
	{
		rigidbody2D.velocity = movement;
	}
	

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;

		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			// Kill the enemy
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);
			
			damagePlayer = true;
		}
		
		// damage player
		if (damagePlayer)
		{
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1);
		}
	}

	void OnDestroy()
	{
		// dun dun dun, gameover
		transform.parent.gameObject.AddComponent<GameOverScript>();
	}
}

