using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth: MonoBehaviour
{
	[SerializeField]
	public List<GameObject> hearts;

	public GameObject deathOverlay;

	private float timer = 0;

	private void Update()
	{
		if (timer >= 0)
		{ timer -= Time.deltaTime; }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (timer <= 0)
		{
			if (collision.gameObject.tag == "Enemy1" || collision.gameObject.tag == "Arrow" || collision.gameObject.tag == "Magic" || collision.gameObject.tag == "Boss" || collision.gameObject.tag == "BossArrow" || collision.gameObject.tag == "BossMagic")
			{
				if (collision.gameObject.tag != "Enemy1" && collision.gameObject.tag != "Boss")
				{ Destroy(collision.gameObject); }

				Destroy(hearts[hearts.Count - 1]);
				hearts.RemoveAt(hearts.Count - 1);
				timer = 3f;
			}
		}

		if (hearts.Count <= 0)
		{
			Destroy(gameObject);
			deathOverlay.SetActive(true);
		}
	}
}
