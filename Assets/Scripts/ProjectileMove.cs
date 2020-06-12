using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = Vector2.zero;
	}

	void FixedUpdate()
    {
		rb.AddForce(transform.up * 5f);
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, 6f);
	}
}
