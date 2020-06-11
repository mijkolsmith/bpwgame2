using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

	public float speed = 1.5f;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;

	Vector3 lastPos;

	[SerializeField]
	float x = 0;
	[SerializeField]
	float y = 0;

    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		x = -2f / 3f * Input.GetAxis("X") + 2f / 3f * Input.GetAxis("Z");
		y = 2f / 3f * Input.GetAxis("X") + 2f / 3f * Input.GetAxis("Z") + Input.GetAxis("Y");

		if (x > 1)
			x = 1;
		if (y > 1)
			y = 1;
		if (x < -1)
			x = -1;
		if (y < -1)
			y = -1;

		//movement
		Vector2 moveInput = new Vector2(x,y);
		moveVelocity = moveInput * speed;

		//rotation
		if (lastPos == null )
		{ lastPos = gameObject.transform.position; }

		Vector3 moveDirection = gameObject.transform.position - lastPos;
		if (moveDirection != Vector3.zero)
		{
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
		}

		if (lastPos != gameObject.transform.position)
		{ lastPos = gameObject.transform.position; }
	}

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

		rb.MoveRotation(rb.rotation * Time.fixedDeltaTime);
	}
}
