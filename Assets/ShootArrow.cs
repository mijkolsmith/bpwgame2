using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{

	GameObject arrow;
	float timer;

    // Update is called once per frame
    void Update()
    {
		timer -= Time.deltaTime;

		if (timer <= 0)
		{
			Instantiate(arrow, new Vector3(1,1,1), Quaternion.identity);
			timer = 5;
		}
    }
}
