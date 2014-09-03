using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
	public int hp = 1;
	private Animator animator;
	public bool isEnemy = true;
	public bool isBoss = false;

	public void Start()
	{
		//displayHit = GameObject.Find ("hitPoint");
		//hitAnimator = displayHit.GetComponent<Animator> ();
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
			if(isEnemy)
			{
				ScoreCounterScript.current_score += 100;
				ScoreCounterScript.enemy_count += 1;

				if(isBoss)
				{
					ScoreCounterScript.current_score += 300;
					SpecialEffectsHelper.Instance.Explosion(transform.position);
					SoundEffectsHelper.Instance.MakeExplosionSound();
				}
			}
			
			else {
				ScoreCounterScript.current_score = 0;
			}

			//hitAnimator.SetBool ("isHit", true);
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
			Destroy(gameObject);
		}
	}	
	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
		if (shot != null)
		{
			if (shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);
				Destroy(shot.gameObject); // target object instead of script
			}
		}
	}
}