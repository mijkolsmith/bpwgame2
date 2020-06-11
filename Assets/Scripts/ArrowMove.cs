﻿using UnityEngine;

public class ArrowMove : MonoBehaviour
{
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
    {
		rb.AddForce(transform.up * .5f);
    }
}
