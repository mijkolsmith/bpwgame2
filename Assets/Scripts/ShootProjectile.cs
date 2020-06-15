using UnityEngine;
using Pathfinding;

public class ShootProjectile : MonoBehaviour
{
	public GameObject projectile;
	AIDestinationSetter ds;

	private void Start()
	{
		ds = GetComponent<AIDestinationSetter>();
	}

	private void Update()
	{
		if (ds != null)
		{
			if (ds.timer <= 0)
			{
				Instantiate(projectile, transform.TransformPoint(new Vector3(0, 0.6f, 0)), transform.rotation);
				ds.timer = 2f;
			}
		}

		if (ds != null)
		{
			if (ds.timer2 <= 0)
			{
				Instantiate(projectile, transform.TransformPoint(new Vector3(-.8f, 1f, 0)), transform.rotation);
				ds.timer2 = 2f;
			}
		}
	}

	public void Shoot(float x, float y)
	{
		float angle = Mathf.Atan2(Input.GetAxis("ShootY"), Input.GetAxis("ShootX")) * Mathf.Rad2Deg;
		Instantiate(projectile, transform.TransformPoint(new Vector3(0, 0.75f, 0)), Quaternion.AngleAxis(angle - 90, Vector3.forward));
	}
}
