using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Booster");
        if (other.tag=="Player")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Player hit Booster");
            player.GetComponent<PlayerManager>().speedIncrease();
            //TODO play music
        }
       
    }
}
