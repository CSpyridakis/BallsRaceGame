using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentManager : MonoBehaviour
{
	public GameObject opponentObject;
	public int OpponentsNum=6;
	public float StartingPoint = -61f;
	
	// Use this for initialization
	void Awake() {
		Debug.Log("Begin Opponents Manager: OK");
		//Create N Opponents
		float diss = 61f/OpponentsNum;
		for (int i =0; i<OpponentsNum; i++)
		{
			spawnOpponent(StartingPoint+(i*diss));
		}
	}

	private void spawnOpponent(float spawnz)
	{
		GameObject gO;
		gO=Instantiate(opponentObject as GameObject);
		gO.transform.SetParent(transform);
		Vector3 mv;
		mv.z = spawnz;
		mv.y = 1f;
		mv.x = Random.Range(-1.75f,8.75f);
		gO.transform.position= mv;
	}

}
