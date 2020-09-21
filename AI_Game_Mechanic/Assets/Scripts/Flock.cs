using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab;
    List<FlockAgent> agents = new List<FlockAgent>(); // store number of agents
    public FlockBehaviour behaviour;

    // Number of agents
    [Range(10, 500)]
    public int startingCount = 250;

    // populate agents in a circle based on the number of agents
    const float AgentDensity = 0.08f;

    // speed booster of agents
    [Range(1f, 100f)]
    public float driveFactor = 10f;

    // max speed
    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    // checker distance of agents
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;
    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier = 0.5f;

    float squareMaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }

    
    void Start()
    {
        squareMaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        // populate the scene with agent
        for (int i = 0; i < startingCount; i++)
        {
            FlockAgent newAgent = Instantiate(
                agentPrefab, // type of agent
                Random.insideUnitSphere /8f * startingCount * AgentDensity, // place it somewhere inside a unit sphere
                Quaternion.Euler(Vector3.left * Random.Range(0f, 360f)), // random rotation
                transform // set parent to the empty game object Flock
                );
            newAgent.name = "agent " + i;
            newAgent.Initialize(this);
            agents.Add(newAgent); // add agent to list to keep track of
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move agents
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            // demo only, badly optimized
            //agent.GetComponentInChildren<Renderer>().material.SetColor("_BaseColor", Color.Lerp(Color.white, Color.red, context.Count / 100f));

            Vector3 move = behaviour.CalculateMove(agent, context, this);
            move *= driveFactor;
            if (move.sqrMagnitude > squareMaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }
            agent.Move(move);
        }
    }

    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighbourRadius);
        foreach(Collider c in contextColliders)
        {
            if (c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
