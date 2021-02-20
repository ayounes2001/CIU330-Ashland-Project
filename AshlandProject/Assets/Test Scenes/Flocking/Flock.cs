﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockAgent agentPrefab; //manually putting in the prefab
    List<FlockAgent> agents = new List<FlockAgent>();
    public FlockBehaviour behaviour; //scriptable object behaviour

    [Range(10, 500)]
    public int startingCount = 20; //our list of birds
    const float AgentDensity = 0.08f; //area our birds will spawn

    [Range(1f, 100f)]
    public float driveFactor = 10f; //speed of the agent

    [Range(1f, 100f)]
    public float maxSpeed = 5f;

    //How we calculate which neighbours count as neighbours
    [Range(1f, 10f)]
    public float neighbourRadius = 1.5f;

    [Range(0f, 1f)]
    public float avoidanceRadiusMultiplier;

    //Radius of the flockagents
    float squaremaxSpeed;
    float squareNeighbourRadius;
    float squareAvoidanceRadius;
    public float SquareAvoidanceRadius { get { return squareAvoidanceRadius; } }



    // Start is called before the first frame update
    void Start()
    {
        squaremaxSpeed = maxSpeed * maxSpeed;
        squareNeighbourRadius = neighbourRadius * neighbourRadius;
        squareAvoidanceRadius = squareNeighbourRadius * avoidanceRadiusMultiplier * avoidanceRadiusMultiplier;

        for(int i = 0; i < startingCount; i++)
        {
            //Creating a prefab in a position where the agents aren't bunched up like sardines

            FlockAgent newAgent = Instantiate(
                 agentPrefab,
                 Random.insideUnitCircle * startingCount * AgentDensity,
                 Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                 transform
                 );

            newAgent.name = "Agent" + i;
            newAgent.Intialize(this);
            agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(FlockAgent agent in agents)
        {
            List<Transform> context = GetNearbyObjects(agent);

            //DEMO ONLY
            // agent.GetComponentInChildren<Renderer>().material.color = Color.Lerp(Color.white, Color.red, context.Count / 6f);


            Vector3 move = behaviour.CalculateMove(agent, context, this); //getting the specfic objects position

            //Actually moving the flock
            move *= driveFactor;
            if (move.sqrMagnitude > squaremaxSpeed)
            {
                move = move.normalized * maxSpeed;
            }

            agent.Move(move);

        }
    }
    List<Transform> GetNearbyObjects(FlockAgent agent)
    {
        //getting all the neighbours next to us and checking whos near us
        List<Transform> context = new List<Transform>();
        Collider[] contextColliders = Physics.OverlapSphere(agent.transform.position, neighbourRadius);

        //adding the collider to the list
        foreach(Collider c in contextColliders)
        {
            if(c != agent.AgentCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }
}
