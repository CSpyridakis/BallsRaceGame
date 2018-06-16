using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
	public float speedDownLimit=5;
	public float speedUpLimit=70.0f;
	public float currentSpeed;
	public float speedIncreaseRate = 5.0f;
	public float leftRightspeed=1000;
	public Rigidbody prB;
	private Vector3 moveV;

	// Use this for initialization
	void Start ()
	{
		currentSpeed = speedDownLimit;
		//Debug.Log("Begin Ball Manager: OK");
	}

	void FixedUpdate()
	{
		playerMovement();
	}
	
	void playerMovement()
	{
		prB.AddForce(leftRightspeed*Input.GetAxisRaw("Horizontal")*Time.deltaTime,0,currentSpeed*Time.deltaTime);
	}


	public void speedIncrease()
	{
		Debug.Log("Speed");
		if (currentSpeed+speedIncreaseRate<=speedUpLimit)
		{
			currentSpeed += speedIncreaseRate;
		}
	}
}
