using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public float waitTime = 3;
	private bool spawnedBoss;
	public GameObject boss;

	private void Update()
	{
		if (waitTime <= 0 && !spawnedBoss)
		{
			Instantiate(boss, GameManager.instance.rooms[GameManager.instance.rooms.Count - 1].room.transform.position, Quaternion.identity);
			spawnedBoss = true;
		}
		else
		{
			waitTime -= Time.deltaTime;
		}
	}
}
