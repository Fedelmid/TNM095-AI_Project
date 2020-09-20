using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))] // script wont work without a collider
public class FlockAgent : MonoBehaviour
{

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } } // access collider without assigned it

    // Instansiate the collider
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }

    // Move the agent according to a certain velocity
    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += velocity * Time.deltaTime;
    }
}
