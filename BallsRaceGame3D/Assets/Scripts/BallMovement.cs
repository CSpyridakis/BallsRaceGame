using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
	public float speedDownLimit=5.0f;
	public float speedUpLimit=70.0f;
	public float currentSpeed=5.0f;
	public float speedDecreaseRate=1.0f;
	public float speedIncreaseRate = 5.0f;
	public float leftRightspeed=14.0f;

	private Vector3 moveV;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void FixedUpdate()
	{
		playerMovement();
	}
	
	void playerMovement()
	{
		moveV =Vector3.zero;

		//Left Right Modement
		moveV.x = (Input.GetAxisRaw("Horizontal")*leftRightspeed)*Time.deltaTime;

		//Forward Movement
		moveV.z = currentSpeed * Time.deltaTime;
		
		//Move
		transform.Translate(moveV.x,0,moveV.z);
	}

	public void speedDecrease()
	{
		if (currentSpeed>speedDownLimit)
		{
			currentSpeed -= speedDecreaseRate;
		}
	}

	public void speedIncrease()
	{
		if (currentSpeed+speedIncreaseRate<=speedUpLimit)
		{
			currentSpeed += speedIncreaseRate;
		}
	}

}
