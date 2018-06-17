using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @brief Camera follows Player with some offset
 */
public class CameraManager : MonoBehaviour
{
	public Transform pT;
	public Vector3 offset;
	private Vector3 moveV;
	
	/*
	 * @brief On Start find out offset based on current camera position
	 */
	void Start ()
	{
		//Debug.Log("Begin Camera Manager: OK");
		offset = transform.position - pT.position;
	}
	
	/*
	 * @brief Call MoveCamera
	*/
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
		
		//Fix X camera movement
		moveV.x = 3.5f;
	
		//Move camera
		transform.position = moveV;
	}
}
