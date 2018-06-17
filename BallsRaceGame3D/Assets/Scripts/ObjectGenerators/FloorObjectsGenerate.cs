using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @brief Spawn random Obstacles or Boost points in each Floor
 */
public class FloorObjectsGenerate : MonoBehaviour
{

	public GameObject[] boosterObjects;
	public GameObject[] obstacleObjects;
	public int difficultyLevel = 1;
	private List<GameObject> spawnedObjects =new List<GameObject>();
	
	/*
	 * @brief Spawn objects based on level difficulty
	 */
	void Start ()
	{
		difficultyLevel = GameObject.FindObjectOfType<GameManage>().gameDifficulty;
		float start = transform.position.z;
		float pos = start;
		
		if (difficultyLevel == 1)
		{
			createRandom(pos + 20f);
			createRandom(pos + 40f);
			createRandom(pos + 60f);
		}
		else if (difficultyLevel == 2)
		{
			createRandom(pos + 15f);
			createRandom(pos + 30f);
			createRandom(pos + 45f);
			createRandom(pos + 60f);
		}
		else
		{
			createRandom(pos + 10f);
			createRandom(pos + 20f);
			createRandom(pos + 30f);
			createRandom(pos + 40f);
			createRandom(pos + 50f);
			createRandom(pos + 60f);
		}
	}

	/*
	 * @brief Spawn Boost with a probability of 0.333 else spawn Obstacle
	 */
	private void createRandom(float spawnz)
	{
		if (Random.Range(0, 23) < 8)
			spawnBooster(spawnz);
	
		else
			spawnObstacle(spawnz);
	}
	
	/*
	 * @brief Spawn Boost in specific position
	 *
	 * @param (float) spawnz z position where to spawn Booster
	 */
	private void spawnBooster(float spawnz)
	{
		GameObject gO;
		gO=Instantiate(boosterObjects[Random.Range(0, boosterObjects.Length)]) as GameObject;
		gO.transform.SetParent(transform);
		Vector3 mv;
		mv.z = spawnz;
		mv.y = 0.05f;
		mv.x = Random.Range(-1.75f,8.75f);
		gO.transform.position= mv;
		spawnedObjects.Add(gO);
	}

	/*
	 * @brief Spawn Obstacle in specific position
	 *
	 * @param (float) spawnz z position where to spawn Obstacle
	 */
	private void spawnObstacle(float spawnz)
	{
		GameObject gO;
		gO=Instantiate(obstacleObjects[Random.Range(0, obstacleObjects.Length)]) as GameObject;
		gO.transform.SetParent(transform);
		Vector3 mv;
		mv.z = spawnz;
		mv.y = 1.5f;
		mv.x = Random.Range(-1.75f,8.75f);
		gO.transform.position= mv;
		spawnedObjects.Add(gO);
	}
}
