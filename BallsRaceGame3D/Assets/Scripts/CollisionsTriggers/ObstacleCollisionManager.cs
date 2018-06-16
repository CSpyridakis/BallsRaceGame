using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionManager : MonoBehaviour
{
	

	private void OnCollisionEnter(Collision other)
	{
		//Debug.Log("Obstacle");
		if (other.collider.tag == "Player")
		{
			Debug.Log("Player hit Obstacle");
			Invoke("Exit",0.3f);
		}
		
	}

	private void Exit()
	{
		GameObject.FindObjectOfType<GameManage>().ExitGame();
	}
}

