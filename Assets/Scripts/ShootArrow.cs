using UnityEngine;
using Pathfinding;

public class ShootArrow : MonoBehaviour
{
	public GameObject arrow;
	float timer = 3f;
	AIDestinationSetter ds;

	private void Start()
	{
		ds = GetComponent<AIDestinationSetter>();
	}

	private void Update()
	{
		if (ds.timer <= 0)
		{
			Instantiate(arrow, transform.TransformPoint(new Vector3(0, 0.6f, 0)), transform.rotation);
			ds.timer = 3f;
		}
	}
}
