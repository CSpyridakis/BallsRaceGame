using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @brief Control Player's movement
 */
public class BallMovementAlternative : MonoBehaviour
{
    
	public float speedDownLimit=5.0f;
	public float speedUpLimit=70.0f;
	public float currentSpeed=5.0f;
	public float speedDecreaseRate=1.0f;
	public float speedIncreaseRate = 1.0f;
	public float leftRightspeed=14.0f;

	private Vector3 moveV;

	void FixedUpdate()
	{
		playerMovement();
		
		if (transform.position.y<-10)
		{
			GameObject.FindObjectOfType<GameManage>().ExitGame();
		}
	}
	
	/*
	 * @brief Change player's position
	 */
	void playerMovement()
	{
		moveV =Vector3.zero;

		//Left Right Movement
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
	
	/*
	 * @brief When player triggered an Booster increase his speed
	 */
	public void speedIncrease()
	{
		if (currentSpeed+speedIncreaseRate<=speedUpLimit)
		{
			currentSpeed += speedIncreaseRate;
		}
	}

}
