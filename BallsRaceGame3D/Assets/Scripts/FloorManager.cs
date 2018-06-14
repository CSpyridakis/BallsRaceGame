﻿using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class FloorManager : MonoBehaviour
{

	/*
	 * Public variables for easy value changing
	 */
	public GameObject[] floorPrefabs;	//all available floors to spawn
	public int numActiveFloors = 10;

	private Transform pT;				//current GameObject Transform Component in order to move it's possition
	private float spawnz = -61f;		//Current floor's spawn z position
	private float floorL = 61f;			//Length of each floor
	private List<GameObject> spawnedFloors =new List<GameObject>();	//List of spawned Floors (In order to delete last one)
	private int lastFloorI = 0;			//Id of last spawned floor
	private int numOfFloorsPassed = 0;	//Number of floors gone through
	
	// Use this for initialization
	void Start()
	{
		//pT = playersTransform
		pT = GameObject.FindGameObjectWithTag("Player").transform;
		
		//Create first N floors
		for (int i =0; i<numActiveFloors; i++)
		{
			spawnFloor();
		}

	}
	// Update is called once per frame
	void Update()
	{
		//Check if new floor needs to been spawned
		if (pT.position.z - 60f>(spawnz-numActiveFloors*floorL))
		{
			spawnFloor();
			DeleteFloor();
		}

	}
	/*
	 * @brief Spawn new Floor
	 */
	private void spawnFloor()
	{
		GameObject gO;
		gO=Instantiate(floorPrefabs[nextFloorRandomPre()]) as GameObject;
		gO.transform.SetParent(transform);
		gO.transform.position= Vector3.forward*spawnz;
		spawnz += floorL;
		spawnedFloors.Add(gO);
	}
	
	/*
	 * @brief Delete Old Floor
	 */
	private void DeleteFloor()
	{
		Destroy(spawnedFloors[0]);
		spawnedFloors.RemoveAt(0);
		numOfFloorsPassed++;
	}

	/*
	 * @brief Select id of new floor
	 */
	private int nextFloorRandomPre()
	{
		//In Case it is first floor or number of floors' ==0 return floor with id==0 (Basic Floor)
		if (floorPrefabs.Length <= 1 || numOfFloorsPassed == 0)
		{
			return 0;
		}

		//While player is in the same floor wait
		int rI = numOfFloorsPassed;
		while (rI==numOfFloorsPassed)
		{
			rI = Random.Range(0, floorPrefabs.Length);
		}
		
		//Return index of new floor
		lastFloorI = rI;
		return lastFloorI;
	}
}
