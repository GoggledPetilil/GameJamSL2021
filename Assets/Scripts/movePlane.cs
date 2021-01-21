using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlane : MonoBehaviour
{
	public GameObject Player;
	public float speed = 30f;
	public Vector3 m_MovDir;

	private void Update()
	{	
		float m_MovX = 0f;
		float m_MovZ = 0f;
		
		// These float values now change based on the WASD keys.
		// W/D will increase the value, while A/S will decrease the value.
		// Less typing than a bunch of if statements.
		m_MovX = Input.GetAxisRaw("Vertical2");
		m_MovZ = Input.GetAxisRaw("Horizontal2");

		// We put these values into a Vector3 to determine how the object moves.
		// Normalized means that the value never goes higher than 1f and never goes lower than -1f.
		m_MovDir = new Vector3(m_MovX, m_MovDir.y, m_MovZ).normalized;
	}

	// FixedUpdate is called 60 times per second. Regardless of FPS. Useful for physics.
	private void FixedUpdate()
	{
		Player.transform.Rotate(m_MovDir * speed * Time.deltaTime);
	}
}
