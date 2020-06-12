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
		if (collision.gameObject.tag == "Enemy1" && timer <= 0 || collision.gameObject.tag == "Arrow" && timer <= 0 || collision.gameObject.tag == "Magic" && timer <= 0)
		{
			if (collision.gameObject.tag != "Enemy1")
			{ Destroy(collision.gameObject); }

			Destroy(hearts[hearts.Count - 1]);
			hearts.RemoveAt(hearts.Count - 1);
			timer = 3f;
		}

		if (hearts.Count <= 0)
		{
			Destroy(gameObject);
			deathOverlay.SetActive(true);
		}
	}
}
