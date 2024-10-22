using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
	public GameObject bombPrefab;
	public GameObject pillPrefab;
	public float spawnInterval;
	public float randomCircleSize = 5;

	private void Start()
	{
		StartCoroutine(SpawnCoroutine());
	}

	private IEnumerator SpawnCoroutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(spawnInterval);
			Spawn();
		}
	}

	private void Spawn()
	{
		Vector2 randomPosition = Random.insideUnitCircle * randomCircleSize;
		switch (Random.Range(0, 2))
		{
			case 0:
				Instantiate(bombPrefab, randomPosition, Quaternion.identity);
				break;
			case 1:
				Instantiate(pillPrefab, randomPosition, Quaternion.identity);
				break;
		}
	}
}

