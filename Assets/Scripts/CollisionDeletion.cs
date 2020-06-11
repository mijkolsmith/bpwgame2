using UnityEngine;

public class CollisionDeletion : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag != "Enemy1" && collision.tag != "Enemy2" && collision.tag != "Enemy3")
		{
			Destroy(gameObject);
		}
	}
}
