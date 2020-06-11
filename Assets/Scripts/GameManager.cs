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

	[SerializeField]
	int seed;

	[SerializeField]
	public List<PlacedRoomData> rooms;

	void Awake()
    {
		if (instance == null)
			instance = this;
		else if (instance != this)
		{
			Destroy(gameObject);
			return;
		}

		rooms = new List<PlacedRoomData>();
		UnityEngine.Random.InitState(seed);
	}
}
