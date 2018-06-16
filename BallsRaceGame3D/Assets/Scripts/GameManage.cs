using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.UIElements;

public class GameManage : MonoBehaviour {
    public int gameDifficulty=0;

    public GameObject GameOver;
    public GameObject GameStatus;
    public GameObject GameMenu;

    private bool first;
    // Use this for initialization
    void Start()
    {
        //Debug.Log("Begin Game Manage: OK");
        PauseGame();
        GameMenu.active=true ;
        GameOver.active = false;
        GameStatus.active = false;
    }

    private void Update()
    {
        //gameDifficulty = ;
        gameDifficulty++;
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
        GameMenu.active=false ;
        GameOver.active = true;
        GameStatus.active = false;
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
        GameMenu.active=false ;
        GameOver.active = false;
        GameStatus.active = true;
    }

    public void ExitGame()
    {
        PauseGame();
        //TODO PlayMusic
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
