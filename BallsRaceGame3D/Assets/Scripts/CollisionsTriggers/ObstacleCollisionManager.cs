using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionManager : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Player")
		{
			//Debug.Log("Player hit Obstacle");
			GameObject.FindObjectOfType<MusicManager>().Play("Obstacle");
			Invoke("Exit",0.1f);
		}
		
	}

	private void Exit()
	{
		GameObject.FindObjectOfType<GameManage>().ExitGame();
	}
}

