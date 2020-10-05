using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/Behaviour/Follow Player")]
public class FollowPlayerBehaviour : FlockBehaviour
{
    public float radius = 1f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 centerOffset = playerPos - agent.transform.position;
        float t = centerOffset.magnitude / radius; // not using sqr cuz to keep proportions
        if (t < 0.9f)
            return Vector3.zero;

        return centerOffset * t * t;
    }
}
