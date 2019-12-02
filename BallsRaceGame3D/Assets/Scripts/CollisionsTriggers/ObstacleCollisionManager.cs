using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollisionManager : MonoBehaviour
{
	public GameObject effect;
	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.tag == "Player")
		{
			//Debug.Log("Player hit Obstacle");
			GameObject.FindObjectOfType<MusicManager>().Play("Obstacle");
			GameObject gO;
			gO=Instantiate(effect,transform.position,transform.rotation);
			gO.transform.SetParent(transform);
			Invoke("Exit",0.1f);
		}
		
	}

	private void Exit()
	{
		GameObject.FindObjectOfType<GameManage>().ExitGame();
	}
}

