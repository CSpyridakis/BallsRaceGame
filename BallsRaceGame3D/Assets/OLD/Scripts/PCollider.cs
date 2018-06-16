using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCollider : MonoBehaviour
{

	//public BallMovement bM;
	
	void Start () {
		Debug.Log("Begin Booster Trigger");
	}

	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Log("Obstacle");
		}  
	}
}
