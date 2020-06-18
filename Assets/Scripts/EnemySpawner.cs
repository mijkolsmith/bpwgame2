using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	Templates templates;
	GameObject[] enemies;

	public void Start()
	{
		templates = GameManager.instance.templates;

		enemies = new GameObject[3];

		enemies[0] = templates.Enemy1;
		enemies[1] = templates.Enemy2;
		enemies[2] = templates.Enemy3;

		int difficulty = GameManager.instance.difficulty;
		if (difficulty <= 1) { difficulty = 2; }
		int rand = Random.Range(difficulty - 2, difficulty + 2); //spawn an amount of enemies 

		//for (int i = 0; i < rand; i++)
		//{
		//	StartCoroutine(SpawnEnemy());
		//}
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
