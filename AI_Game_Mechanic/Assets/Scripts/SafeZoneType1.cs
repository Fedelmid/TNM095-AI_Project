using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneType1 : MonoBehaviour
{
    public CompositeBehaviour compositeBehaviour;
    public PlayerStats playerStats;
    int followWeightIndex;

    private void Start()
    {
        // Find the index for the follow player behaviour
        for (int i = 0; i < compositeBehaviour.behaviours.Length; i++)
        {
            if (compositeBehaviour.behaviours[i].GetType() == typeof(FollowPlayerBehaviour))
            {
                followWeightIndex = i;
                break;
            }
        }
    }

    // Player in safe zone, stop the flock from following the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            compositeBehaviour.weights[followWeightIndex] = 0f;
            playerStats.isInvincible = true;
        }
    }

    // Player in the swarm zone, swarm will follow player
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            compositeBehaviour.weights[followWeightIndex] = 4f;
            playerStats.isInvincible = false;
        }
    }
}
