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

	[SerializeField, Tooltip("Define a seed here for the random generation")]
	int seed;

	[SerializeField]
	public List<PlacedRoomData> rooms;

	public Templates templates;

	[Tooltip("Difficulty can't be lower than 2")]
	public int difficulty = 2;

	[HideInInspector]
	public float spawnTime = .5f; //you don't want to edit this
	
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

		UnityEngine.Random.InitState(seed);

		templates = GetComponent<Templates>();

		rooms = new List<PlacedRoomData>();
	}

	private void Update()
	{
		spawnTime -= Time.deltaTime;

		if (spawnTime <= 0 && !scan)
		{
			AstarPath.active.Scan();
			scan = true;
		}
	}
}
