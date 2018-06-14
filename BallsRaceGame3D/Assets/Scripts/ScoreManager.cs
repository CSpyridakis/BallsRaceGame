using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public Text scoreBoard;

	private float score=0.0f;
	
	// Use this for initialization
	void Start () {
		score = scoreUpdate(score, 0.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		score = scoreUpdate(score, Time.deltaTime);
	}
	
	public float scoreUpdate(float s,float acv)
	{
		s+=acv;
		int scor = (int) s;
		//scor /= 10;
		scoreBoard.text = scor.ToString();
		return s;
	}
}
