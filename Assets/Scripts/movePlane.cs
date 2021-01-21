using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class movePlane : MonoBehaviour
{
	public GameObject Player;
	public float speed = 30f;
	public float m_MaxAngle;
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
		float m_RotationX = m_MaxAngle * m_MovDir.x;
		float m_RotationY = 0f;
		float m_RotationZ = m_MaxAngle * m_MovDir.z;

		Quaternion target = Quaternion.Euler(m_RotationX, m_RotationY, m_RotationZ);
		
		//Player.transform.rotation = Quaternion.Euler(m_RotationX, m_RotationY, m_RotationZ);
		Player.transform.rotation = Quaternion.RotateTowards(transform.rotation, target, speed * Time.deltaTime);
	}
}
