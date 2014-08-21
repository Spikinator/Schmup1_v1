﻿using UnityEngine;

// enemy behavior
public class EnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;


	void Awake()
	{
		weapons = GetComponentsInChildren<WeaponScript>();
		moveScript = GetComponent<MoveScript>();
	}
	
	// 1 - Disable everything
	void Start()
	{
		hasSpawn = false;
		collider2D.enabled = false;

		moveScript.enabled = false;
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = false;
		}
	}
	
	void Update()
	{
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false)
		{
			if (renderer.IsVisibleFrom(Camera.main))
			{
				Spawn();
			}
		}
		else
		{
			// Auto-fire
			foreach (WeaponScript weapon in weapons)
			{
				if (weapon != null && weapon.enabled && weapon.CanAttack)
				{
					weapon.Attack(true);
					SoundEffectsHelper.Instance.MakeEnemyShotSound();
				}
			}
			
			// 4 - Out of the camera ? Destroy the game object.
			if (renderer.IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}
	}
	
	// 3 - Activate itself.
	private void Spawn()
	{
		hasSpawn = true;
		
		// Enable everything
		collider2D.enabled = true;
		moveScript.enabled = true;

		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = true;
		}
	}
}