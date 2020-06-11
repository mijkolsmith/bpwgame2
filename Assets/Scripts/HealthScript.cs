using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
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
		if (collision.gameObject.name == "Enemy1" && timer <= 0 || collision.gameObject.tag == "Arrow" && timer <= 0 || collision.gameObject.tag == "Magic" && timer <= 0)
		{
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
