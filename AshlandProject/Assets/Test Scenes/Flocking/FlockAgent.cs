using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;

    public float force = 20;
    public Flock AgentFlock { get { return agentFlock; } }
    Collider agentCollider;

    public Collider AgentCollider { get { return agentCollider; } }
    // Start is called before the first frame update
    void Start()
    {
        agentCollider = GetComponent<Collider>();
    }

    public void Intialize(Flock flock)
    {
        agentFlock = flock;
    }
    public void Move(Vector3 velocity)
    {
        velocity = new Vector3(velocity.x, 0, velocity.z);
        transform.forward = velocity;

        gameObject.GetComponent<Rigidbody>().AddForce(velocity * force * Time.deltaTime);
        //transform.position += velocity * Time.deltaTime;
        //Quaternion.LookRotation(Vector3.left,velocity);
    }
}

