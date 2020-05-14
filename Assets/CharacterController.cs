using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

	public float speed = 1.5f;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;

	float x = 0;
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
			
		Debug.Log(x);
		Debug.Log(y);

		Vector2 moveInput = new Vector2(x,y);
		moveVelocity = moveInput * speed;
    }

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
	}
}
