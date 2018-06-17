using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 * @brief Control movement foreach opponent
 */
public class OpponentMovement : MonoBehaviour {

	public float currentSpeed=11.0f;
	public float speedIncreaseRate = 1.0f;
	public float speedUpLimit = 70.0f;
	public float leftRightspeed=20.0f;
	public float checkDistance = 20.0f;
	public float offsetCheck = 0.53f;

	private Vector3 moveV;
	private int lastob =0;
	void Start ()
	{
		//Debug.Log("Begin Ball Movement: OK");
		currentSpeed=Random.Range(7f,16f);
	}
	
	void FixedUpdate()
	{
		playerMovement();

		if (transform.position.y<-100)
		{
			Destroy(gameObject);
		}
	}
	
	/*
	* @brief Move Oppoment position
	*/
	void playerMovement()
	{
		moveV =Vector3.zero;

		//Left Right Modement
		moveV.x = leftRightMovement()* Time.deltaTime;

		//Forward Movement
		moveV.z = currentSpeed * Time.deltaTime;
		
		//Move
		transform.Translate(moveV.x,0,moveV.z);
	}
	
	/*
	 * @brief When opponent triggered with a Booster increase his speed
	 */
	public void speedIncrease()
	{
		if (currentSpeed+speedIncreaseRate<=speedUpLimit)
		{
			currentSpeed += speedIncreaseRate;
		}
	}
	
	/*
	 * @brief Find Obstacles position and move opponent left or right in order to avoid them  
	 */
	public float leftRightMovement()
	{
		RaycastHit hit;
		Vector3 leftCheck = transform.position;
		leftCheck.x = leftCheck.x-offsetCheck;
		Vector3 rightCheck = transform.position;
		rightCheck.x = rightCheck.x+offsetCheck;

		Debug.DrawRay(leftCheck, transform.forward,Color.yellow);
		Debug.DrawRay(transform.position, transform.forward,Color.green);
		Debug.DrawRay(rightCheck, transform.forward,Color.blue);
		
		//Left collision Check
		if (Physics.Raycast(leftCheck, transform.forward, out hit))
		{
			if (hit.distance<checkDistance)
			{
				lastob = 1;
				//Fix Direction in case of Error
				if(transform.position.x<-1.2f)
					lastob = 1;
				else if (transform.position.x>8.4f)
					lastob = -1;
				return lastob*leftRightSpeed(hit.distance);
			}
		}
		//Right collision Check
		else if (Physics.Raycast(rightCheck, transform.forward, out hit))
		{
			if (hit.distance<checkDistance)
			{
				lastob = -1;
				//Fix Direction in case of Error
				if(transform.position.x<-1.2f)
					lastob = 1;
				else if (transform.position.x>8.4f)
					lastob = -1;
				return lastob*leftRightSpeed(hit.distance);
			}
		}
		//Middle Collision Check
		else if (Physics.Raycast(transform.position, transform.forward, out hit))
		{
			if (hit.distance<checkDistance)
			{
				findDirection();
				return lastob*leftRightSpeed(hit.distance);
			}
		}
		//No Collision
		else
		{
			lastob = 0;
		}
		
		return 0.0f;
	}
	/*
	 * @brief Find opponents speed based on his distance until obstacle
	 *
	 * @param (float) distance , Distance of collision 
	 */
	private float leftRightSpeed(float distance)
	{
		return leftRightspeed / distance;
	}
		
	/*
	 * @brief Find if opponent has to move left or right
	 */
	private void findDirection()
	{
		RaycastHit right;
		RaycastHit left;
		Physics.Raycast(transform.position, Vector3.right, out right);
		Physics.Raycast(transform.position, Vector3.left, out left);
		
		//Middle Case
		if (Math.Abs(right.distance-left.distance)<0.5f && lastob==0)
		{
			lastob = Random.Range(0, 1) == 0 ? -1 : 1;
		}
		//Move right case
		else if(left.distance<right.distance && lastob==0)
		{
			lastob = 1;
		}
		//Move left case
		else if(lastob==0)
		{
			lastob = -1;
		}
		
		//Fix Direction in case of Error
		if(transform.position.x<-1.2f)
			lastob = 1;
		else if (transform.position.x>8.4f)
			lastob = -1;
	}
	
	/*
	 * @brief If opponent triggered with Booster or Obstacle act properly
	 */
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Booster")
		{
			//Debug.Log("Enemy Booster");
			speedIncrease();
		}
        
		if (other.tag == "Obstacle")
		{
			//Debug.Log("Enemy Obstacle");
			Destroy(gameObject);
		}
	}
}
