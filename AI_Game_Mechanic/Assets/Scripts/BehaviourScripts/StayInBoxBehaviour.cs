using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Flock/Behaviour/Stay in box")]
public class StayInBoxBehaviour : FlockBehaviour
{
    public Vector3 center;
    public Vector3 boxLimit;
    public float radius = 15f;

    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //Bounds bc = boxLimit.GetComponent<BoxCollider>().bounds;
        float xSize = boxLimit.x / 2.0f;
        float ySize = boxLimit.y / 2.0f;
        float zSize = boxLimit.z / 2.0f;

        Vector3 ap = center - agent.transform.position;
        bool insideBox = (ap.x < xSize && ap.x > -xSize && ap.y < ySize && ap.y > -ySize && ap.z < zSize && ap.z > -zSize) ? true : false;

        Vector3 centerOffset = center - agent.transform.position;
        float t = centerOffset.magnitude / radius; // not using sqr cuz to keep proportions

        if (insideBox)
            return Vector3.zero;

        return centerOffset * t * t;
    }
    
}
