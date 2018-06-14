using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{

	public GameObject[] floorPrefab;
	public int numActiveFloors = 10;

	private Transform pT;
	private float spawnz = 61f;
	private float floorL = 61f;

	// Use this for initialization
	void Start()
	{
		pT = GameObject.FindGameObjectWithTag("Player").transform;
		spawnFloor();
		spawnFloor();
		spawnFloor();
		spawnFloor();

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void spawnFloor(int prI=-1)
	{
		GameObject gO;
		gO=Instantiate(floorPrefab[0]) as GameObject;
		gO.transform.SetParent(transform);
		gO.transform.position= Vector3.forward*spawnz;
		spawnz += floorL;
	}

}
