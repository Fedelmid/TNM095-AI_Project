using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public CompositeBehaviour compositeBehaviour;
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
        }
    }

    // Player in the swarm zone, swarm will follow player
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            compositeBehaviour.weights[followWeightIndex] = 4f;
        }
    }
}
