using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FlockBehaviour : ScriptableObject
{
    //Using the flockagents around us and getting their list of positions
    //Abstract functions dont need a body
    public abstract Vector3 CalculateMove(FlockAgent agent, List<Transform> context, Flock flock);
   
}
