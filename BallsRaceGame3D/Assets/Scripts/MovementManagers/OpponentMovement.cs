using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/*
 * @brief Control movement foreach opponent
 */
public class OpponentMovement : MonoBehaviour {

	public float currentSpeed=11.0f;
	public float speedIncreaseRate = 1.0f;
	public float speedUpLimit = 70.0f;
	public float leftRightspeed=10.0f;

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
		RaycastHit right;
		RaycastHit left;

		if (Physics.Raycast(transform.position, transform.forward, out hit))
		{
			if (hit.distance<20.0f)
			{
				Physics.Raycast(transform.position, Vector3.right, out right);
				Physics.Raycast(transform.position, Vector3.left, out left);
				if (Math.Abs(right.distance-left.distance)<1 && lastob==0)
				{
					lastob = Random.Range(0, 1) == 0 ? -1 : 1;
				}
				else if(left.distance<right.distance && lastob==0)
				{
					lastob = 1;
				}
				else if(lastob==0)
				{
					lastob = -1;
				}
				if(transform.position.x<-1.2f)
					lastob = 1;
				else if (transform.position.x>8.4f)
					lastob = -1;
				
				return lastob*leftRightspeed;
			}
		}
		else if (Physics.Raycast(transform.position, transform.forward*Mathf.Sin(+30), out hit))
		{
			if (hit.distance < 10.0f)
			{
				lastob = -1;
			}
		}
		else if (Physics.Raycast(transform.position, transform.forward*Mathf.Sin(-30), out hit))
		{
			if (hit.distance < 10.0f)
			{
				lastob = 1;
			}
		}
		
		
		return 0.0f;
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
