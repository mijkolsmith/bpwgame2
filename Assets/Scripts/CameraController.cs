using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;
	private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
		if (player != null)
		{
			transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 5), ref velocity, Time.deltaTime * 1f);
		}
	}
}
