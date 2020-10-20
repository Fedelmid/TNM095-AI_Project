using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/Behaviour/Cohesion")]
public class CohesionBehaviour : FilteredFlockBehaviour
{

    // find middle point between all neighbours and try to move there
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbours, return no adjustment
        if (context.Count == 0)
            return Vector3.forward;

        // add all points together and average
        Vector3 cohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            // check if other agent is in current agent's fov
            float y = item.position.z - agent.transform.position.z;
            float x = item.position.x - agent.transform.position.x;
            float angleBetweenAgents = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            bool inView = (angleBetweenAgents < (90f + agent.fieldOfView / 2)) && (angleBetweenAgents > (90f - agent.fieldOfView / 2));

            if(inView)
                cohesionMove += item.position;
        }
        cohesionMove /= filteredContext.Count;

        // create offset from agent position
        cohesionMove -= agent.transform.position;
        return cohesionMove;
    }
}
