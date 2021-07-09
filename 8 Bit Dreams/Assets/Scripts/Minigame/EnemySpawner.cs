using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	[SerializeField] private GameObject enemyReference;
	[SerializeField] private float firstReduce;
	[SerializeField] private float cicleReduce;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private float timeOfAction;
	[SerializeField] private GameObject bossReference;
	void Start()
	{
		InvokeRepeating("Spawn", firstReduce, cicleReduce);
		Invoke("StopSpawn", timeOfAction);
		Invoke("SpawnBoss", timeOfAction + cicleReduce);
	}
	void Spawn()
	{
		var point = spawnPoints[Random.Range(0, spawnPoints.Length)];
		Instantiate(enemyReference, point.position, point.rotation);
	}
	void StopSpawn()
	{
		CancelInvoke("Spawn");
	}
	void SpawnBoss()
	{
		Instantiate(bossReference);
	}
}
