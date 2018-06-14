using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

	private Transform pT;
	private Vector3 offset;
	private Vector3 moveV;
	
	// Use this for initialization
	void Start () {
		//Find players object based on tag
		pT = GameObject.FindGameObjectWithTag("Player").transform;
		
		//Create offset
		offset = transform.position - pT.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveLight();
	}
	
	/*
	 * @brief Move light based on player's possition
	 */
	void moveLight()
	{
		//Find player's position 
		moveV = pT.position + offset;

		//Fix light movements
		moveV.x = -5;
		moveV.y = 13;
		
		//Move light
		transform.position = moveV;
	}
}
