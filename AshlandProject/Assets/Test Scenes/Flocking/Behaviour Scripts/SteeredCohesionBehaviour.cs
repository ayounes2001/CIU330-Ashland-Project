﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Flock/Behaviour/SteeredCohesion")]
public class SteeredCohesionBehaviour : FilteredFlockBehavior
{
    Vector3 currentVelocity;
    public float agentSmoothTime =  0.5f; //current state to calculated state


    //Finding middle point of all neighbours
    public override Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {

        //if no neighbours, return no adjustment
        if (context.Count == 0)
        {
            return Vector3.zero;
        }
        //add all points together and average
        Vector3 cohesionMove = Vector3.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            cohesionMove += item.position;
        }

        cohesionMove /= context.Count;

        //create offset from agent position

        cohesionMove -= agent.transform.position;

        cohesionMove = Vector3.SmoothDamp(agent.transform.forward, cohesionMove, ref currentVelocity, agentSmoothTime);

        return cohesionMove;
    }
}
