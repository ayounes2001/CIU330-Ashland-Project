using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;



public class Smoketrigger : MonoBehaviour
{
  
    public GameObject ButtonSmoke;
    public GameObject ButtonSmokeClicked;
    ParticleSystem buttonSmoke;

    public float animDuration;

    public Ease ease;

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
