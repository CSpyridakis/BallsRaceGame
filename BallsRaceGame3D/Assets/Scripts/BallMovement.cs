using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    
	public float speed=20.0f;
	public float lRspeed=1.0f;

	private Vector3 moveV;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void FixedUpdate()
	{
		playerMovement();
	}
	
	void playerMovement()
	{
		moveV =Vector3.zero;

		//Left Right Modement
		moveV.x = (Input.GetAxisRaw("Horizontal")*lRspeed)*Time.deltaTime;

		//Forward Movement
		moveV.z = speed * Time.deltaTime;
		
		//Move
		transform.Translate(moveV.x,0,moveV.z);
	}

}
