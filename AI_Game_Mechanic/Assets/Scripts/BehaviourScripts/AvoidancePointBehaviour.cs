using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Avoidance")]
public class AvoidancePointBehaviour : FilteredFlockBehaviour
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
            // check if other agent is in current agent's fov
            float y = item.position.z - agent.transform.position.z;
            float x = item.position.x - agent.transform.position.x;
            float angleBetweenAgents = Mathf.Atan2(y,x) * Mathf.Rad2Deg;
            bool inView = (angleBetweenAgents < (90f + agent.fieldOfView / 2)) && (angleBetweenAgents > (90f - agent.fieldOfView / 2));

            if (inView && Vector3.SqrMagnitude(item.position - agent.transform.position) < flock.SquareAvoidanceRadius)
            {
                nAvoid++;
                avoidanceMove += (agent.transform.position - item.position); // move away
            }
        }
                
        if (nAvoid > 0)
            avoidanceMove /= nAvoid;

        return avoidanceMove;
    }
}
