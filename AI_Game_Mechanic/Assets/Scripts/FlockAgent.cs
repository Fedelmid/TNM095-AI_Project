using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))] // script wont work without a collider
public class FlockAgent : MonoBehaviour
{

    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    Collider agentCollider;
    public Collider AgentCollider { get { return agentCollider; } } // access collider without assigned it

    [HideInInspector]
    public float fieldOfView;

    // Instansiate the collider
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    // Move the agent according to a certain velocity
    public void Move(Vector3 velocity)
    {           
        if(!(float.IsNaN(velocity.x) || float.IsNaN(velocity.y) || float.IsNaN(velocity.z)))
        {
            transform.forward = velocity;
            transform.position += velocity * Time.deltaTime;
        } 
    }
}
