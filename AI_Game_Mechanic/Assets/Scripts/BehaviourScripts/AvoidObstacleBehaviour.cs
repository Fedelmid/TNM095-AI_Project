using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/Behaviour/Avoid Obstacle")]
public class AvoidObstacleBehaviour : FilteredFlockBehaviour
{
    // move away from neighbours
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbours, return no adjustment
        if (context.Count == 0)
            return Vector3.forward;

        // add all points together and average
        Vector3 avoidanceMove = Vector3.zero;      

        int nAvoid = 0; // number of avoidances

        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            // Avoid entire object
            Vector3 closestPoint = item.gameObject.GetComponent<Collider>().ClosestPoint(agent.transform.position);
            if (Vector3.SqrMagnitude(closestPoint - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += (agent.transform.position - closestPoint); // move away
            }
        }

        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}
