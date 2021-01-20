using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlane : MonoBehaviour
{
	public GameObject Player;

	public float speed = 30f;

	private void Update()
	{
		if (Input.GetKey(KeyCode.W) )
		{
			//Player.transform.rotation = Quaternion.Euler(new Vector3(15, 0, 0));
			Player.transform.Rotate(speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.A))
		{
			//Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 15));
			Player.transform.Rotate(0, 0, speed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.S))
		{
			//Player.transform.rotation = Quaternion.Euler(new Vector3(-15, 0, 0));
			Player.transform.Rotate(-speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey(KeyCode.D))
		{
			//Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -15));
			Player.transform.Rotate(0, 0, -speed * Time.deltaTime);
		}
	}
}
