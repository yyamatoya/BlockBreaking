using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public bool isDead = false;
	public float speed = 3.0f;	//	‘¬“x
	public float accelSpeed = 0.5f; // ‰Á‘¬“x

	public ScoreManager scoreManager;
	public GameObject explosionPrefab;

	bool isStart = false;
	Rigidbody rb;
	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update()
	{
		if (!isStart && Input.GetMouseButton(0))
		{
			isStart = true;
			rb.AddForce(new Vector3(1, -1, 0) * speed, ForceMode.VelocityChange);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Block"))
		{
			scoreManager.AddScore();
			Destroy(collision.gameObject);
			GameObject explosion = Instantiate(explosionPrefab, collision.transform.position, Quaternion.identity);
			explosion.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
		}
		if (collision.gameObject.name == "Wall_Bottom")
		{
			isDead = true;
		}

		if(collision.gameObject.name == "Bar")
		{
			scoreManager.ResetCombo();
			speed += accelSpeed;
			Vector3 vec = transform.position - collision.transform.position;
			rb.velocity = Vector3.zero;
			rb.AddForce(vec.normalized *speed, ForceMode.VelocityChange);
		}
	}
}
