using UnityEngine;

public class EnemyHealth: MonoBehaviour
{
	[SerializeField]
	int lives = 0;

	[SerializeField]
	GameObject Trapdoor;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			Destroy(collision.gameObject);
			lives--;
		}

		if (lives <= 0)
		{
			if (gameObject.tag == "Boss")
			{
				Trapdoor = Instantiate(Trapdoor, transform.position, Quaternion.identity);
				Debug.Log(Trapdoor);
			}
			Destroy(gameObject);
		}
	}
}
