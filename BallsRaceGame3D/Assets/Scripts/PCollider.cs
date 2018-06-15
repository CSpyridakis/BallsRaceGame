using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCollider : MonoBehaviour
{

	public BallMovement bM;
	
	void Start () {
		Debug.Log("Begin Ball Collider");
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("Booster"))
		{
			bM.speedIncrease();
			Debug.Log("Boost");
		}  
	}
}
