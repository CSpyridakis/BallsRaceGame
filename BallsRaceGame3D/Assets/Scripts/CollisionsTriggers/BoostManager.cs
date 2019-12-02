using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    public GameObject effect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            //Debug.Log("Player hit Booster");
            GameObject.FindObjectOfType<MusicManager>().Play("Boost");
            GameObject gO;
            gO=Instantiate(effect,transform.position,transform.rotation);
            gO.transform.SetParent(transform);
            other.GetComponent<BallMovementAlternative>().speedIncrease();
            other.GetComponent<ScoreManager>().scoreUpdate(150);
        }
    }
}
