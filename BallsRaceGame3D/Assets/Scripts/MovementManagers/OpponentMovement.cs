using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @brief Control movement foreach opponent
 */
public class OpponentMovement : MonoBehaviour {

	public float currentSpeed=11.0f;
	public float speedIncreaseRate = 1.0f;
	public float speedUpLimit = 70.0f;
	public float leftRightspeed=14.0f;

	private Vector3 moveV;

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
		moveV.x = leftRightMovement();

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
		//TODO CHANGE BASED ON OBSTACLES
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
