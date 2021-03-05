using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_Ambience : MonoBehaviour
{
    EventInstance amb;
    [SerializeField] F_FmodEvents fmodEvent;

    void Start()
    {
        StartAmbience();
    }

    void StartAmbience()
    {
        amb = RuntimeManager.CreateInstance(fmodEvent.eventPath);
        amb.start();
        amb.release();
    }

    private void OnDestroy()
    {
        amb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

}
