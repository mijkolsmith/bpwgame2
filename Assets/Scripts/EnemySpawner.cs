using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	Templates templates;
	GameObject[] enemies;

	int minEnemies = 1;
	int maxEnemies = 3;

	public void Start()
	{
		templates = GameManager.instance.templates;

		enemies = new GameObject[3];

		enemies[0] = templates.Enemy1;
		enemies[1] = templates.Enemy2;
		enemies[2] = templates.Enemy3;

		int rand = Random.Range(minEnemies, maxEnemies); //spawn a minimum and a maximum enemies
		for (int i = 0; i < rand; i++)
		{
			StartCoroutine(SpawnEnemy());
		}
	}

	IEnumerator SpawnEnemy()
	{
		int rand = Random.Range(0, enemies.Length);
		Vector3 Pos = gameObject.transform.localPosition;

		yield return new WaitForSeconds(GameManager.instance.spawnTime);

		Instantiate(enemies[rand], new Vector3(Pos.x + Random.Range(-2f,2f), Pos.y + Random.Range(-3f,3f), Pos.z), Quaternion.identity, transform);

		yield return null;
	}
}
