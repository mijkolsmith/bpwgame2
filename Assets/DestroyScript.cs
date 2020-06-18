using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("SpawnPoint"))
		{
			Destroy(collision.gameObject);
		}
		else if (collision.name == "Collider")
		{
			Destroy(collision.transform.parent.gameObject);
		}
	}
}
