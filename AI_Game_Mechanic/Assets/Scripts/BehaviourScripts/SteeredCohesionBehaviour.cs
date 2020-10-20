using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Steered Cohesion")]
public class SteeredCohesionBehaviour : FilteredFlockBehaviour // smoother type of cohesion, no flickering
{

    Vector3 currentVelocity;
    public float agentSmoothTime = 0.7f; // 0.5 sec kinda, dependent on frame rate


    // find middle point between all neighbours and try to move there
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbours, return no adjustment
        if (context.Count == 0)
            return Vector3.forward;

        currentVelocity = Vector3.zero; // need to set this in order to avoid NaN error in smoothDamp

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
        cohesionMove = Vector3.SmoothDamp(agent.transform.forward, cohesionMove, ref currentVelocity, agentSmoothTime);

        if (float.IsNaN(cohesionMove.x) || float.IsNaN(cohesionMove.y) || float.IsNaN(cohesionMove.z))
        {
            cohesionMove -= agent.transform.position;
            return cohesionMove;
        }

        return cohesionMove;
    }
}
