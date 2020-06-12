using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
	[SerializeField]
	int lives = 0;

	private void Start()
	{
		if (gameObject.tag == "Enemy1")
		{
			lives = 2;
		}
		if (gameObject.tag == "Enemy2")
		{
			lives = 3;
		}
		if (gameObject.tag == "Enemy3")
		{
			lives = 2;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			Destroy(collision.gameObject);
			lives--;
		}

		if (lives <= 0)
		{
			Destroy(gameObject);
		}
	}
}
