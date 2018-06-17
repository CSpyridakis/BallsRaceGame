using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public Text scoreBoard;
	public Text GameOverScore;
	public Text distanceBoard;
	public Text playerPossition;
	public Transform pT;

	private float score=0.0f;

	/*
	 * @brief Each frame update score, distance and position
	 */
	void Update ()
	{
		scoreUpdate(1);
		PlayerPoss();
		distanceUpdate(pT.transform);
	}
	
	/*
	 * @brief Update player's distance in GameInfo Panel
	 *
	 * @param (Transform) pt PlayersTransform based on is calculating distance that player has traveled so far
	 */
	public void distanceUpdate(Transform pt)
	{
		Vector3 dis = pt.position;
		int dista = (((int) ((dis.z + 61f) / 10)) * 10);
		distanceBoard.text = dista.ToString();
		if ((dis.z + 61f)%100 == 0)
			scoreUpdate(100);
	}
	
	/*
	 * @brief Update score in both GameInfo Panel and GameOver Panel
	 *
	 * @param (float) sta Score To Add in scoreboards
	 */
	public void scoreUpdate(float sta)
	{
		score+=sta;
		scoreBoard.text = ((int)score).ToString();
		GameOverScore.text= ((int)score).ToString();
	}
	
	/*
	 * @brief Find out current player's position and update GameInfo Panel
	 */
	private void PlayerPoss()
	{
		float playerZ = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.z;
		int poss= 1;
		foreach (var o in GameObject.FindGameObjectsWithTag("Enemy"))
		{
			if (o.transform.position.z>playerZ)
			{
				poss++;
			}
		}
		playerPossition.text = poss.ToString();
	}
}
