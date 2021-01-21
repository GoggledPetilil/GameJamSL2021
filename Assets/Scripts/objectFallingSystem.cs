using System.Collections;
using UnityEngine;

public class objectFallingSystem : MonoBehaviour
{
	public int indexFallingObjects;

	public GameObject Ball;

	public GameObject[] fallingObjects;

	float waitSeconds = 5f;
	float waitSecondsPlus = .1f;

	int instatiateNum;

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

		instatiateNum = Random.Range(0, indexFallingObjects);

		GameObject clone = Instantiate(fallingObjects[instatiateNum], new Vector3(Ball.transform.position.x, Ball.transform.position.y + 5, Ball.transform.position.z), Quaternion.identity);

		Destroy(clone, 20);

		yield return new WaitForSeconds(waitSeconds);
		waitSeconds = waitSeconds - waitSecondsPlus;

		StartCoroutine(ObjectInstantiater());
	}
}