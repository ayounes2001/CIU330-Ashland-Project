using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class F_Player : MonoBehaviour
{
    [SerializeField] F_FmodEvents footstepEvents;
    
    public void DingoStep()
    {
        EventInstance dingoFootstep = RuntimeManager.CreateInstance(footstepEvents.eventPath);
        dingoFootstep.start();
        dingoFootstep.release();
    }
}
