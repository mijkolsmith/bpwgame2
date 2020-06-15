using UnityEngine;

public class CollisionDeletion : MonoBehaviour
{
	//i know this script is called collisiondeletion but some magic flew around chasing the player endlessly
	float lifeTime = 10f;

	private void Update()
	{
		lifeTime -= Time.deltaTime;

		if (lifeTime == 0)
		{
			Destroy(gameObject);
		}
	}

	//deletion of projectiles when colliding with each other or walls/obstacles. Only not true for boss projectiles
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "Enemy1" && collision.tag != "Enemy2" && collision.tag != "Enemy3" && collision.tag != "Player" && collision.tag != "Boss")
		{
			if (gameObject.tag == "BossMagic" || gameObject.tag == "BossArrow")
			{
				if (collision.tag != "Magic" && collision.tag != "Arrow")
				{
					Destroy(gameObject);
				}
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
