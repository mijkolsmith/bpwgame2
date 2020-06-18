﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			GameManager.instance.seed = (int)DateTime.Now.Ticks;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
