using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilteredFlockBehaviour
{
    // find where agent should be faceing
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        // if no neighbours, maintain current alignment
        if (context.Count == 0)
            return agent.transform.forward;

        // add all points together and average
        Vector3 alignmentMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            // check if other agent is in current agent's fov
            float y = item.position.z - agent.transform.position.z;
            float x = item.position.x - agent.transform.position.x;
            float angleBetweenAgents = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            bool inView = (angleBetweenAgents < (90f + agent.fieldOfView / 2)) && (angleBetweenAgents > (90f - agent.fieldOfView / 2));

            if(inView)
                alignmentMove += item.transform.forward;
        }

        if(filteredContext.Count > 0)
            alignmentMove /= filteredContext.Count;

        return alignmentMove;
    }
}
