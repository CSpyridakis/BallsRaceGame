using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCollider : MonoBehaviour
{

	public BallMovement bM;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Obstacle")
		{
			bM.enabled = false;
			Debug.Log("Dead");
		}    
		
		if (other.collider.tag == "Booster")
		{
			bM.speedIncrease();
			Debug.Log("Boost");
		}  
	}
}
