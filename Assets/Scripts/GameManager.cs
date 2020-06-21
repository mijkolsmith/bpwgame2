using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlacedRoomData
{
	public int lastOpeningDirection;
	public GameObject room;
}

public class GameManager : MonoBehaviour
{
	internal static GameManager instance = null;

	[Tooltip("Define a seed here for the random generation")]
	public int seed;

	[Tooltip("Randomize the seed each playthrough")]
	public bool enableRandomization;

	[SerializeField]
	public List<PlacedRoomData> rooms;

	public Templates templates;

	[Tooltip("Difficulty can't be lower than 2")]
	public int difficulty = 2;

	public float spawnTime = 1f; //edit in inspector
	
	bool scan = false;

	void Awake()
    {
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
			return;
		}

		//randomized seed
		if (enableRandomization)
		{
			seed = (int)DateTime.Now.Ticks;
		}

		//seed initialization
		UnityEngine.Random.InitState(seed);


		templates = GetComponent<Templates>();
		rooms = new List<PlacedRoomData>();
	}

	private void Update()
	{ //do a new scan after the dungeon has generated
		spawnTime -= Time.deltaTime;

		if (spawnTime <= .1f && !scan)
		{
			AstarPath.active.Scan();
			scan = true;
		}
	}
}
