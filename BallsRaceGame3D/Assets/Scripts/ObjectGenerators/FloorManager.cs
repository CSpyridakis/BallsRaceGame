using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using UnityEngine;

public class FloorManager : MonoBehaviour
{

	/*
	 * Public variables for easy value changing
	 */
	public GameObject[] floorPrefabs;		//all available floors to spawn
	public GameObject[] buildingsPrefabs;	//all available buildings to spawn
	public int numActiveFloors = 10;
	
	public float spawnz = -61f;				//Current floor's spawn z position
	private Transform pT;					//current GameObject Transform Component in order to move it's possition
	private float floorL = 61f;				//Length of each floor
	private List<GameObject> spawnedFloors =new List<GameObject>();	//List of spawned Floors (In order to delete last one)
	private List<GameObject> spawnedBuildings =new List<GameObject>();	//List of spawned Floors (In order to delete last one)
	private int lastFloorI = 0;				//Id of last spawned floor
	private int numOfFloorsPassed = 0;		//Number of floors gone through
	
	// Use this for initialization
	void Start()
	{
		//Debug.Log("Begin Floor Manager: OK");
		//pT = playersTransform
		pT = GameObject.FindGameObjectWithTag("Player").transform;
		
		//Create first N floors
		for (int i =0; i<numActiveFloors; i++)
		{
			spawnBoth();
		}

	}
	// Update is called once per frame
	void Update()
	{
		//Debug.Log("pt.position.z: "+pT.transform.position.z+"  spawzn: "+spawnz + " numActiveFloors: "+numActiveFloors + " floorL:"+floorL );
		//Check if new floor needs to been spawned
		if (pT.transform.position.z - 70f>(spawnz-numActiveFloors*floorL))
		{
			spawnBoth();
			DeleteBoth();
		}

	}

	private void spawnBoth()
	{
		spawnFloor();
		spawnBuildings();
		spawnz += floorL;
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
		spawnedFloors.Add(gO);
	}
	/*
	 * @brief Spawn new Building
	 */
	private void spawnBuildings()
	{
		GameObject gO;
		gO=Instantiate(buildingsPrefabs[Random.Range(0, buildingsPrefabs.Length)]) as GameObject;
		gO.transform.SetParent(transform);
		gO.transform.position= Vector3.forward*spawnz;
		spawnedBuildings.Add(gO);
	}
	
	/*
	* @brief Delete Both
	*/
	private void DeleteBoth()
	{
		DeleteFloor();
		DeleteBuilding();
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
	 * @brief Delete Old Building
	 */
	private void DeleteBuilding()
	{
		Destroy(spawnedBuildings[0]);	 
		spawnedBuildings.RemoveAt(0);
	}
	
	
	/*
	 * @brief Select id of new floor
	 */
	private int nextFloorRandomPre()
	{
		//In Case it is first floor or number of floors' ==0 return floor with id==0 (Basic Floor)
		if (floorPrefabs.Length <= 1 || lastFloorI == 0)
		{
			lastFloorI++;
			return 0;
		}
		//Select random floor != first
		int rI= Random.Range(1, floorPrefabs.Length);
		//Return index of new floor
		return rI;
	}
}
