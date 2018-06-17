using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Experimental.UIElements;

public class GameManage : MonoBehaviour {
    public int gameDifficulty=1;

    public GameObject GameOver;
    public GameObject GameStatus;
    public GameObject GameMenu;

    private bool first;

    /*
     * @brief On start Pause player's and opponents' movement and show up GameMenu
     */
    void Start()
    {
        //Debug.Log("Begin Game Manage: OK");
        PauseGame();
        GameMenu.active=true ;
        GameOver.active = false;
        GameStatus.active = false;
    }

    /*
     * @brief Pause Player's and opponents' movement and show up GameOver
     */
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

    /*
     * @brief Start Player's and opponents movement and show up GameStatus
     */
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

    /*
     * @brief Call it whenever Exit needed
     */
    public void ExitGame()
    {
        PauseGame();
    }

    /*
     * @brief Restart Game in current scene
     */
    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    
    /*
    * @brief Quit game only when build
    */
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
