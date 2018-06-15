using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
	private Transform pT;
	private Vector3 offset;
	private Vector3 moveV;
	
	// Use this for initialization
	void Start ()
	{
		Debug.Log("Begin Camera Manager");
		//Find players object based on tag
		pT = GameObject.FindGameObjectWithTag("Player").transform;
		
		//Create offset
		offset = transform.position - pT.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveCamera();
	}

	/*
	 * @brief Move camera based on player's possition
	 */
	void moveCamera()
	{
		//Find player's position 
		moveV = pT.position + offset;
		
		//Fix camera movements
		moveV.x = 3.5f;
	
		//Move camera
		transform.position = moveV;
	}
}
