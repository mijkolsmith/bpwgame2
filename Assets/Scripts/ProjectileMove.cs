using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
    {
		rb.AddForce(transform.up*3f);
    }
}
