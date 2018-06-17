using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            //Debug.Log("Player hit Booster");
            GameObject.FindObjectOfType<MusicManager>().Play("Boost");
            other.GetComponent<BallMovementAlternative>().speedIncrease();
            other.GetComponent<ScoreManager>().scoreUpdate(150);
        }
    }
}
