using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneType2 : MonoBehaviour
{

    public PlayerStats playerStats;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
            playerStats.isInvincible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
            playerStats.isInvincible = false;
    }
}
