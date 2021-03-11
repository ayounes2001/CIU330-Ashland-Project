using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawnTest : MonoBehaviour
{
    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

   
    public Vector3 center;
    public Vector3 size;
    public Material Grass;

    public LayerMask grassMask;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        
    }

public void SpawnObject()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(spawnee, pos, Quaternion.identity);

        

        if(stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }

        Destroy(spawnee, 10f);
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == grassMask)
        {
            Grass.SetColor("_Tint", Color.black);
            Grass.SetColor("Darker", Color.black);
           
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }
}
