using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class F_Player : MonoBehaviour
{
    [SerializeField]
    private string footstepEvent;
    [SerializeField]
    private string materialParameter;
    
    public void DingoStep()
    {
        EventInstance dingoFootstep = RuntimeManager.CreateInstance(footstepEvent);
        dingoFootstep.setParameterByName(materialParameter, 1);
        dingoFootstep.start();
        dingoFootstep.release();
    }
}
