using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmFollow : MonoBehaviour
{
    public CompositeBehaviour compositeBehaviour;
    int followWeightIndex;

    private void Start()
    {
        // Find the inde for follow player behaviour
        for(int i = 0; i < compositeBehaviour.behaviours.Length; i++)
        {
            if(compositeBehaviour.behaviours[i].GetType() == typeof(FollowPlayerBehaviour))
            {
                followWeightIndex = i;
                break;
            }
        }
    }

    // Player in the swarm zone, swarm will follow player
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            compositeBehaviour.weights[followWeightIndex] = 4f;
        }
    }

    // Player exited swarm zone, swarm will stop following the player
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            compositeBehaviour.weights[followWeightIndex] = 0f;
        }
    }
}
