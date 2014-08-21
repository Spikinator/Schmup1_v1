using UnityEngine;

public class HealthScript : MonoBehaviour
{
	public int hp = 1;
	private Animator animator;
	public bool isEnemy = true;


	public void Start()
	{
		animator = this.GetComponent<Animator> ();
	}

	public void Update()
	{

	}

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
				// 'Splosion!
				//SpecialEffectsHelper.Instance.Explosion(transform.position);
				
				// SOUND
				SoundEffectsHelper.Instance.MakeExplosionSound();
				// Dead!

			if(isEnemy)
			{
				ScoreCounterScript.score += 100;
				Destroy(gameObject, 0.3f);
				animator.SetBool ("IsDestroyed", true);
			}


			else {
				ScoreCounterScript.score = 0;
				Destroy(gameObject, 0.1f);
			}


		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		// Is this a shot?
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			// Avoid friendly fire
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				
				// Destroy the shot
				Destroy(shot.gameObject); // Remember to always target the game object, otherwise you will just remove the script
			}
		}
	}
}