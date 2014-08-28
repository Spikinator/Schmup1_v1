using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class MoveScript : MonoBehaviour
{
	// 1 - Designer variables
	
	/// <summary>
	/// Object speed
	/// </summary>
	public Vector2 speed = new Vector2(10, 10);
	public float test;

	public static float rand1 = Random.Range (160.0F, 190.0F);
	public static float rand2 = Random.Range (-160.0F, 190.0F);
	/// <summary>
	/// Moving direction
	/// </summary>
	public Vector2 rotation;
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;
	
	void Update()
	{
		// 2 - Movement
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
		//test = Random.Range(-100.0F, 100.0F);


		//rotation = new Vector2 (rand1, rand2);
	}
	
	void FixedUpdate()
	{
		// Apply movement to the rigidbody
		rigidbody2D.velocity = movement;
	}
}