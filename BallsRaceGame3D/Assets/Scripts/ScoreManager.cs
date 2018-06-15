using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

	public Text scoreBoard;
	public Text distanceBoard;
	public Transform pT;

	private float score=0.0f;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		scoreUpdate(Time.deltaTime);
		distanceUpdate(pT.transform);
	}
	
	public void distanceUpdate(Transform pt)
	{
		Vector3 dis = pt.position;
		distanceBoard.text = (((int)(dis.z/10))*10).ToString();
	}
	
	public void scoreUpdate(float acv)
	{
		score+=acv;
		scoreBoard.text = ((int)score).ToString();
	}
}
