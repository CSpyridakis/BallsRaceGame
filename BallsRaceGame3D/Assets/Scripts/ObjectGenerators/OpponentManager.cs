using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @brief Spawn Opponents
 */
public class OpponentManager : MonoBehaviour
{
	public GameObject opponentObject;
	public int OpponentsNum=10;
	public int multyplier = 1;
	public float StartingPoint = -61f;
	
	/*
	* @brief Spawn N opponents in pseudo-random places
	*/
	void Awake()
	{
		//Debug.Log("Begin Opponents Manager: OK");
		OpponentsNum *= multyplier;
		StartingPoint *= multyplier;
		
		//Create N Opponents
		float diss = (61f*multyplier)/OpponentsNum;
		for (int i =0; i<OpponentsNum; i++)
		{
			spawnOpponent(StartingPoint+(i*diss));
		}
	}

	/*
	 * @brief Spawn Opponent in specific position
	 *
	 * @param (float) spawnz z position where to spawn Opponent
	 */
	private void spawnOpponent(float spawnz)
	{
		GameObject gO;
		gO=Instantiate(opponentObject as GameObject);
		gO.transform.SetParent(transform);
		Vector3 mv;
		mv.z = spawnz;
		mv.y = 1f;
		mv.x = Random.Range(-1f,8.4f);
		gO.transform.position= mv;
	}

}
