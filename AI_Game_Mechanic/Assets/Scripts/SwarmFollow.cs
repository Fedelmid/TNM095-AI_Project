using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmFollow : MonoBehaviour
{
    public CompositeBehaviour compositeBehaviour;
    int followWeightIndex;

    private void Start()
    {
        for(int i = 0; i < compositeBehaviour.behaviours.Length; i++)
        {
            if(compositeBehaviour.behaviours[i].GetType() == typeof(FollowPlayerBehaviour))
            {
                followWeightIndex = i;
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            compositeBehaviour.weights[followWeightIndex] = 4f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            compositeBehaviour.weights[followWeightIndex] = 0f;
        }
    }
}
