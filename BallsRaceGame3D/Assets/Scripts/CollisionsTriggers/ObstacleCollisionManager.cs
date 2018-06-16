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
			other.collider.GetComponent<PlayerManager>().enabled=false;
			other.collider.GetComponent<ScoreManager>().enabled=false;
			other.collider.GetComponent<BallMovementAlternative>().enabled=false;
			//TODO play music
			//TODO exit
		}
	}
}

