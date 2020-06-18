using UnityEngine;

public class CharacterController : MonoBehaviour
{

	public float speed = 1.5f;
	private Rigidbody2D rb;
	private Vector2 moveVelocity;

	Vector3 lastPos;

	[SerializeField]
	float shootSpeed = .75f;

	[SerializeField]
	float x = 0;
	[SerializeField]
	float y = 0;

	ShootProjectile sp;
	private float timer = 0f;

	[SerializeField]
	GameObject loading;

	void Start()
    {
		sp = GetComponent<ShootProjectile>();
		rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		/* this is old code of using hexagonal movement. I decided to remove this because it didn't play well.
		x = -2f / 3f * Input.GetAxis("X") + 2f / 3f * Input.GetAxis("Z");
		y = 2f / 3f * Input.GetAxis("X") + 2f / 3f * Input.GetAxis("Z") + Input.GetAxis("Y");

		if (x > 1)
			x = 1;
		if (y > 1)
			y = 1;
		if (x < -1)
			x = -1;
		if (y < -1)
			y = -1;*/
		
		//have a loading screen while the game is loading
		if (GameManager.instance.spawnTime >= 0f)
		{ loading.SetActive(true); }
		else
		{ loading.SetActive(false); }

		//rotation calculations
		if (lastPos == null)
		{ lastPos = gameObject.transform.position; }

		Vector3 moveDirection = gameObject.transform.position - lastPos;

		if (Input.GetAxis("ShootX") == 0 && Input.GetAxis("ShootY") == 0)
		{
			if (moveDirection != Vector3.zero)
			{
				float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
			}
		}
		else if (Input.GetAxis("ShootX") != 0 || Input.GetAxis("ShootY") != 0)
		{
			float angle = Mathf.Atan2(Input.GetAxis("ShootY"), Input.GetAxis("ShootX")) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
		}

		if (lastPos != gameObject.transform.position)
		{ lastPos = gameObject.transform.position; }
		
		//shooting
		timer -= Time.deltaTime;

		if (Input.GetButton("ShootX") && timer <= 0f || Input.GetButton("ShootY") && timer <= 0f)
		{
			sp.Shoot(Input.GetAxis("ShootX"), Input.GetAxis("ShootY"));
			timer = shootSpeed;
		}
	}

	private void FixedUpdate()
	{
		//movement calculations
		x = Input.GetAxis("X");
		y = Input.GetAxis("Y");

		Vector2 moveInput = new Vector2(x, y);
		moveVelocity = moveInput * speed;

		//movement and rotation applications
		rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

		rb.MoveRotation(rb.rotation * Time.fixedDeltaTime);
	}
}
