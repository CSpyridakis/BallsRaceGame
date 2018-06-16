using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {
    public int gameDifficulty=1;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Begin Game Manage: OK");
        //PauseGame();
        PlayGame();
    }
    
    
    public void PauseGame()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().enabled=false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().enabled=false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovementAlternative>().enabled=false;
        foreach (var o in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            o.GetComponent<OpponentMovement>().enabled = false;
        }
    }

    public void PlayGame()
    {
        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().enabled=true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>().enabled=true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovementAlternative>().enabled=true;
        foreach (var o in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            o.GetComponent<OpponentMovement>().enabled = true;
        }
    }

    public void ExitGame()
    {
        PauseGame();
        //TODO PlayMusic
        //TODO RESTART
    }
}
