using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoketrigger : MonoBehaviour
{
  
    public GameObject ButtonSmoke;
    public GameObject ButtonSmokeClicked;
    ParticleSystem buttonSmoke;
    // Update is called once per frame
    void Start() 
    {
        buttonSmoke = ButtonSmoke.GetComponent<ParticleSystem>();
    }
    private void OnMouseEnter()
    {
        buttonSmoke.time = 0;
        buttonSmoke.Play();
     
    }
  
}
