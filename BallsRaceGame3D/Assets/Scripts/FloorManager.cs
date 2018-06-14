using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{

	public GameObject[] floorPrefab;
	public int numActiveFloors = 10;

	private Transform pT;
	private float spawnz = -61f;
	private float floorL = 61f;
	private List<GameObject> spawnedFloors =new List<GameObject>();
	private int lastFloorI = 0;
	private int numOfFloorsPassed = 0;
	
	// Use this for initialization
	void Start()
	{
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
		if (pT.position.z - 60f>(spawnz-numActiveFloors*floorL))
		{
			spawnFloor();
			DeleteFloor();
		}

	}

	private void spawnFloor()
	{
		GameObject gO;
		gO=Instantiate(floorPrefab[nextFloorRandomPre()]) as GameObject;
		gO.transform.SetParent(transform);
		gO.transform.position= Vector3.forward*spawnz;
		spawnz += floorL;
		spawnedFloors.Add(gO);
	}

	private void DeleteFloor()
	{
		Destroy(spawnedFloors[0]);
		spawnedFloors.RemoveAt(0);
		numOfFloorsPassed++;
	}

	private int nextFloorRandomPre()
	{
		if (floorPrefab.Length <= 1 || numOfFloorsPassed == 0)
		{
			return 0;
		}

		int rI = numOfFloorsPassed;
		while (rI==numOfFloorsPassed)
		{
			rI = Random.Range(0, floorPrefab.Length);
		}

		lastFloorI = rI;
		return lastFloorI;
	}
}
