using System.Collections;
using UnityEngine;

public class objectFallingSystem : MonoBehaviour
{
	//public int indexFallingObjects;

	public GameObject Ball;

	public GameObject[] fallingObjects;

	float waitSeconds = 5f;
	float waitSecondsPlus = 0.1f;

	//int instatiateNum;

	public void Start()
	{
		StartCoroutine(ObjectInstantiater());
	}

	IEnumerator ObjectInstantiater()
	{
		if(waitSeconds <= 0.8f)
		{
			waitSecondsPlus = 0f;
		}

		// Array.Length gives you a value equal to the length of the array.
		// So If the array has 3 objects, you get 3.
		// No need for a new variable to store that.
		int instatiateNum = Random.Range(0, fallingObjects.Length);
		// You also don't really need to make instantiateNum a global variable (the variables at the top)
		// Make this a temporary variable, since you only need this var for this Courotine to instantiate stuff.
		// You never need it anywhere else. So make it a temporary variable.
		
		if (Ball == null)
		{
			// To give the GameManager time to get access to the Player, since both are called on the Start funciton.
			// Otherwise, it will say GameManager has nothing.
			yield return new WaitForSeconds(0.1f);
			Ball = GameManager.instance.m_Player;
		}

		// The falling object's position is largely based on the Ball's position.
		// So, I'll create a temporary value called pos, which is equal to the Ball's position and
		// add to that a position modifier.
		Vector3 posMod = new Vector3(0f, 0.5f, 0f);
		Vector3 pos = Ball.transform.position + posMod;

		// This helps keeps the code a bit cleaner.
		GameObject clone = Instantiate(fallingObjects[instatiateNum], pos, Quaternion.identity);

		Destroy(clone, 20);

		yield return new WaitForSeconds(waitSeconds);
		waitSeconds -= waitSecondsPlus;
		// -= means it takes its own value and then subtracks from itself the given value.
		// It's less writing than doing [a = a - b]
		// [a -= b] is the exact same as [a = a - b]

		StartCoroutine(ObjectInstantiater());
	}
}