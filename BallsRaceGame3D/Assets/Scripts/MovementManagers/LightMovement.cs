using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovement : MonoBehaviour {

	public Transform pT;
	private Vector3 offset;
	private Vector3 moveV;
	
	// Use this for initialization
	void Start () {
		//Debug.Log("Begin Light Manager: OK");
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
		moveV.x = -10;
		moveV.y = 14;
		
		//Move light
		transform.position = moveV;
	}
}
