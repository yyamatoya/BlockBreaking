using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
	float posX;
	float posY;

	// Start is called before the first frame update
	void Start()
	{

		posY = transform.position.y;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 pos = Input.mousePosition;
		Vector3 targetPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));
		targetPos.x = Mathf.Clamp(targetPos.x, -1.6f, 1.6f);
		targetPos.y = posY;
		transform.position = targetPos;
	}
}
