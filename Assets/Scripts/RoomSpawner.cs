using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
	public int openingDirection;
	//1 = top
	//2 = right
	//3 = bottom
	//4 = left

	private RoomTemplates templates;
	private int rand;
	private bool spawned = false;

	public float waitTime = 4f;

	private void Start()
	{
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.2f);
	}

	void Spawn()
    {
		if (spawned == false)
		{
			PlacedRoomData data = new PlacedRoomData();
			GameObject go = null;
			switch (openingDirection)
			{
				case 1: //spawn a room with bottom opening
					rand = Random.Range(0, templates.bottomRooms.Length);
					go = Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
					break;
				case 2: //spawn a room with left opening
					rand = Random.Range(0, templates.leftRooms.Length);
					go = Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
					break;
				case 3: //spawn a room with top opening
					rand = Random.Range(0, templates.topRooms.Length);
					go = Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
					break;
				case 4: //spawn a room with right opening
					rand = Random.Range(0, templates.rightRooms.Length);
					go = Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
					break;
			}

			data.lastOpeningDirection = openingDirection;
			if (go != null)
			{ data.room = go; }

			GameManager.instance.rooms.Add(data);

			spawned = true;
		}
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true)
		{
			Destroy(gameObject);
		}
	}
}
