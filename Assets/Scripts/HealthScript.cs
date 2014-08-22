using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour
{
	public int hp = 1;
	private Animator animator;
	public bool isEnemy = true;

	/*private GameObject displayHit;
	private Animator hitAnimator;*/

	public bool delay = false;

	public void Start()
	{
		//displayHit = GameObject.Find ("hitPoint");
		//hitAnimator = displayHit.GetComponent<Animator> ();
		animator = this.GetComponent<Animator> ();
	}

	public void Update()
	{
		if (delay) {
			//StartCoroutine(Wait());
		}
	}

	IEnumerator Wait()
	{
			yield return new WaitForSeconds(3);
	}

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0)
		{
				
			if(isEnemy)
			{
				//hitAnimator.SetBool ("isHit", true);
				// 'Splosion!
				SpecialEffectsHelper.Instance.Explosion(transform.position);
				
				// SOUND
				SoundEffectsHelper.Instance.MakeExplosionSound();
				// Dead!


				ScoreCounterScript.score += 100;
				Destroy(gameObject);
				animator.SetBool ("IsDestroyed", true);

				//hitAnimator.SetBool ("isHit", false);
			}


			else {

				// 'Splosion!
				SpecialEffectsHelper.Instance.Explosion(transform.position);
				// SOUND
				SoundEffectsHelper.Instance.MakeExplosionSound();
				// Dead!

				ScoreCounterScript.score = 0;

				StartCoroutine(Wait());

				delay = true;
				Destroy(gameObject, 2.0f);
				StartCoroutine(Wait ());
				Application.LoadLevel("LoseScene");
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