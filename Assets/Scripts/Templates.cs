using UnityEngine;

public class Templates : MonoBehaviour
{
	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public GameObject Enemy1;
	public GameObject Enemy2;
	public GameObject Enemy3;

	public GameObject boss;
	private bool spawnedBoss;

	private void Update()
	{
		//spawn the boss in the last room
		if (GameManager.instance.spawnTime <= 0 && !spawnedBoss)
		{
			Instantiate(boss, GameManager.instance.rooms[GameManager.instance.rooms.Count - 1].room.transform.position, Quaternion.identity);
			spawnedBoss = true;
		}
	}
}
