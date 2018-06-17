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
	public float lrOffset = 4f;
	
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
	/*
	 * @brief Find opponents speed based on his distance until obstacle
	 *
	 * @param (float) distance , Distance of collision
	 * @param (float) x, current players position
	 */
	public float leftRightMovement()
	{
		//Raycasts
		RaycastHit hitForward;
		RaycastHit hitLeft;
		RaycastHit hitRight;
		Vector3 leftCheck = transform.position;
		leftCheck.x = leftCheck.x-offsetCheck;
		Vector3 rightCheck = transform.position;
		rightCheck.x = rightCheck.x+offsetCheck;

		//Collisions Check and Visual show up
		Physics.Raycast(leftCheck, transform.forward, out hitForward);
		Physics.Raycast(rightCheck, transform.forward, out hitLeft);
		Physics.Raycast(transform.position, transform.forward, out hitRight);
		//Debug.DrawRay(leftCheck, transform.forward,Color.yellow);
		//Debug.DrawRay(transform.position, transform.forward,Color.green);
		//Debug.DrawRay(rightCheck, transform.forward,Color.blue);
		
		//Out of scene Case
		GameObject fl = GameObject.FindGameObjectWithTag("Floor");
		float leftFloorPoss=fl.transform.position.x-lrOffset;
		float rightFloorPoss = fl.transform.position.x + lrOffset;
		
		//Forward Collision
		if ((hitForward.distance<hitLeft.distance) && (hitForward.distance<hitRight.distance) && (hitForward.distance<checkDistance))
		{
			findDirection();
			return lastob*leftRightSpeed(hitForward.distance, transform.position.x);
		}
		//Left Collision
		else if ((hitLeft.distance < hitForward.distance) && (hitLeft.distance < hitRight.distance) && (hitLeft.distance < checkDistance))
		{
			findDirection();
			return lastob*leftRightSpeed(hitLeft.distance, transform.position.x);
		}
		//Right Collision
		else if ((hitRight.distance < hitForward.distance) && (hitRight.distance < hitLeft.distance) && (hitRight.distance < checkDistance))
		{
			findDirection();
			return lastob*leftRightSpeed(hitRight.distance, transform.position.x);
		}
		//No Collision
		else if(transform.position.x>leftFloorPoss && transform.position.x <rightFloorPoss )
		{
			lastob = 0;
		}
		
		return 0.0f;
	}

	private float leftRightSpeed(float distance, float x)
	{
		GameObject fl = GameObject.FindGameObjectWithTag("Floor");
		float leftFloorPoss=fl.transform.position.x-lrOffset;
		float rightFloorPoss = fl.transform.position.x + lrOffset;
		//Opponent out in scene
		if (x > leftFloorPoss && x < rightFloorPoss)
		{
			if (distance > checkDistance)
			{
				return 0.1f;
			}
			else if (distance == 0.0f)
			{
				return leftRightspeed;
			}

			return leftRightspeed / distance;
		}
		//Opponent out off scene
		else
		{
			return leftRightspeed * 2;
		}
	}
		
	/*
	 * @brief Find if opponent has to move left or right
	 */
	private void findDirection()
	{
		GameObject fl = GameObject.FindGameObjectWithTag("Floor");
		float leftFloorPoss=fl.transform.position.x-lrOffset;
		float rightFloorPoss = fl.transform.position.x + lrOffset;

		float distanceToRight=Math.Abs(transform.position.x-leftFloorPoss);
		float distanceToLeft=Math.Abs(transform.position.x-rightFloorPoss);
		
		//Middle Case
		if (Math.Abs(distanceToRight-distanceToLeft)<0.5f && lastob==0)
		{
			lastob = Random.Range(0, 1) == 0 ? -1 : 1;
		}
		//Move right case
		else if(distanceToLeft<distanceToRight && lastob==0)
		{
			lastob = 1;
		}
		//Move left case
		else if(distanceToLeft>distanceToRight && lastob==0)
		{
			lastob = -1;
		}
		
		//Fix Direction in case of Error
		if(transform.position.x<leftFloorPoss)
			lastob = 1;
		else if (transform.position.x>rightFloorPoss)
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
