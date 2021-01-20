using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathCollider : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Ball")
		{
			SceneManager.LoadScene("Level");
		}
	}
}
