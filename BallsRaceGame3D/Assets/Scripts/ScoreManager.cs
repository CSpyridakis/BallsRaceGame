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
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		PlayerPoss();
		distanceUpdate(pT.transform);
	}
	
	public void distanceUpdate(Transform pt)
	{
		
		Vector3 dis = pt.position;
		int dista = (((int) ((dis.z + 61f) / 10)) * 10);
		distanceBoard.text = dista.ToString();
		if (dista % 100 == 0)
			scoreUpdate(1000);
	}
	
	public void scoreUpdate(float acv)
	{
		score+=acv;
		scoreBoard.text = ((int)score).ToString();
		GameOverScore.text= ((int)score).ToString();
	}

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
