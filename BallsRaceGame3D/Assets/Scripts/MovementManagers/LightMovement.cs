using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @brief Control Light Movement
 */
public class LightMovement : MonoBehaviour {

	public Transform pT;
	private Vector3 offset;
	private Vector3 moveV;
	
	/*
	 * @brief Find out offset
	 */
	void Start () {
		//Debug.Log("Begin Light Manager: OK");
		offset = transform.position - pT.position;
	}
	
	/*
	 * @brief Move Light
	 */
	void Update ()
	{
		moveLight();
	}
	
	/*
	 * @brief Move light based on player's position
	 */
	void moveLight()
	{
		//Find player's position 
		moveV = pT.position + offset;

		//Fix x and y light movements
		moveV.x = -10;
		moveV.y = 14;
		
		//Move light
		transform.position = moveV;
	}
}
