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
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			Debug.Log("Player hit Obstacle");
			player.GetComponent<PlayerManager>().enabled=false;
			//TODO play music
		}
	}
}

