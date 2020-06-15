using UnityEngine;
using Pathfinding;

public class ShootMagic : MonoBehaviour
{
	public GameObject magic;
	AIDestinationSetter ds;

	private void Start()
	{
		ds = GetComponent<AIDestinationSetter>();
	}

	private void Update()
	{
		if (ds.timer <= 0)
		{
			Instantiate(magic, transform.TransformPoint(new Vector3(0, 0.75f, 0)), Quaternion.identity);
			ds.timer = 3f;
		}

		if (ds.timer2 == 2)
		{
			Instantiate(magic, transform.TransformPoint(new Vector3(0, 0.75f, 0)), Quaternion.identity);
		}
	}
}
