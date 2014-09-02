using UnityEngine;

public class WeaponScript : MonoBehaviour
{

	public Transform shotPrefab;
	public float shootingRate = 0.25f;

	public float max = 0.0f;
	public float min = 0.0f;

	public float getRot;

	private float shootCooldown;

	public static float rand1;
	
	void Start()
	{
		shootCooldown = 0f;

	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;
			
			// Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;
			shotTransform.rotation = transform.rotation;
			// Assign position
			shotTransform.position = transform.position;

			
			// The is enemy property
			ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}
			
			// Make the weapon shot always towards it
			MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
			getRot = (float)move.test;
			if (move != null)
			{
				rand1 = Random.Range (min, max);
				//Transform parentTransform = other.gameObject.transform.parent.transform;
				move.direction = this.transform.right; // towards in 2D space is the right of the sprite
				//Debug.Log (rand1);
				//this.transform.Rotate(0, 0, rand1);
				this.transform.Rotate(0, 0, rand1);
			}

			//shotTransform.transform.Rotate(0, getRot, 0);
		}
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
