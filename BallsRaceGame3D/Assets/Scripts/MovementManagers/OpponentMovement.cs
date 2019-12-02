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

	public float currentSpeed=11.0f;		//
	public float speedIncreaseRate = 2.0f;
	public float speedUpLimit = 70.0f;
	public float leftRightspeed=20.0f;
	public float checkDistance = 50.0f;
	public float offsetCheck = 0.53f;
	public float lrOffset = 4f;
	public GameObject Boosteffect;
	public GameObject Collisioneffect;

	private float leftFloorPoss;
	private float rightFloorPoss;
	private Vector3 moveV;
	private int lastob =0;
	private int ID;
	
	void Start ()
	{
		ID = Random.Range(0, 10000);
		GameObject fl = GameObject.FindGameObjectWithTag("Floor");
		leftFloorPoss = -1f;    //Testing: 0.1f | Real left pos: -1f  | Second test: fl.transform.position.x-lrOffset;
		rightFloorPoss = 8.4f;  //Testing: 7.1f | Real right pos: 8.4 | Second test: fl.transform.position.x + lrOffset;
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
		//Debug.DrawRay(leftCheck, transform.forward*hitLeft.distance,Color.yellow);
		//Debug.DrawRay(transform.position, transform.forward*hitForward.distance,Color.green);
		//Debug.DrawRay(rightCheck, transform.forward*hitRight.distance,Color.blue);
		
		//Forward Collision
		if ((hitForward.distance<hitLeft.distance) && (hitForward.distance<hitRight.distance) && (hitForward.distance<checkDistance+currentSpeed) && hitForward.collider.CompareTag("Obstacle"))
		{
			findDirection(0);
			return lastob*leftRightSpeed(hitForward.distance, transform.position.x);
		}
		//Left Collision
		else if ((hitLeft.distance < hitForward.distance) && (hitLeft.distance < hitRight.distance) && (hitLeft.distance < checkDistance+currentSpeed)&& hitLeft.collider.CompareTag("Obstacle"))
		{
			findDirection(-1);
			return lastob*leftRightSpeed(hitLeft.distance, transform.position.x);
		}
		//Right Collision
		else if ((hitRight.distance < hitForward.distance) && (hitRight.distance < hitLeft.distance) && (hitRight.distance < checkDistance+currentSpeed)&& hitRight.collider.CompareTag("Obstacle"))
		{
			findDirection(1);
			return lastob*leftRightSpeed(hitRight.distance, transform.position.x);
		}
		//No Collision
		else if(transform.position.x>leftFloorPoss && transform.position.x <rightFloorPoss )
		{
			lastob = 0;
		}
		return 0.0f;
	}

	/*
	 * @brief Find opponents speed based on his distance until obstacle
	 *
	 * @param (float) distance , Distance of collision
	 * @param (float) x, current players position
	 */
	private float leftRightSpeed(float distance, float x)
	{

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

			return leftRightspeed / distance + currentSpeed %10;
		}
		//Opponent out off scene
		else
		{
			return leftRightspeed * 2;
		}
	}
		
	/*
	 * @brief Find if opponent has to move left or right
	 *
	 * @param collisionFrom, position from where collision is going to happen
	 */
	private void findDirection(int collisionFrom)
	{
		float distanceToRight=Math.Abs(transform.position.x-leftFloorPoss);
		float distanceToLeft=Math.Abs(transform.position.x-rightFloorPoss);
		
		//Middle Case
		if (Math.Abs(distanceToRight-distanceToLeft)<0.1f && lastob==0)
		{
			//If collision from left move right
			if (collisionFrom==-1)
			{
				lastob = 1;
			}
			//If collision from right move left
			else if(collisionFrom==1)
			{
				lastob = -1;
			}
			//If collision from middle random select
			else
			{
				lastob = Random.Range(0, 1) == 0 ? -1 : 1;
			}
		}
		//Move left case
		else if(distanceToLeft<distanceToRight && lastob==0)
		{
			lastob = -1;
		}
		//Move right case
		else if(distanceToLeft>distanceToRight && lastob==0)
		{
			lastob = 1;
		}
		
		//Fix Direction in case of Error
		if (transform.position.x < leftFloorPoss)
		{
			lastob = 1;
		}
		else if (transform.position.x > rightFloorPoss)
		{
			lastob = -1;
		}
	}
	
	/*
	 * @brief If opponent triggered with Booster or Obstacle act properly
	 */
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Booster")
		{	
			//GameObject gO;
			//gO=Instantiate(Boosteffect,other.transform.position,other.transform.rotation);
			//gO.transform.SetParent(other.transform);
			//gO.GetComponent<MeshRenderer>().enabled = false;
			//gO.GetComponent<BoostManager>().enabled = false;
			//Debug.Log("Enemy Booster");
			speedIncrease();
			//String delBo = "DeleteBoost(" + other + ")";
			//Invoke(delBo, 0.1f);
		}
        
		if (other.tag == "Obstacle")
		{
			GameObject gO;
			gO=Instantiate(Collisioneffect,transform.position,transform.rotation);
			gO.transform.SetParent(transform);
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			//Debug.Log("Enemy Obstacle");
			Invoke("DeleteCollide",0.1f);
		}
	}

	private void DeleteBoost(GameObject gO)
	{
		gO.active = false;
		//Destroy(gO);
	}

	private void DeleteCollide()
	{
		Destroy(gameObject);
	}
}
