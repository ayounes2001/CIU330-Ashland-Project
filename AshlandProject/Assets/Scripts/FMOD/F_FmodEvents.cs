using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fmod Event", menuName = "Fmod Event")]
public class F_FmodEvents : ScriptableObject
{
    [FMODUnity.EventRef]
    public string eventPath;
    public string eventType;
    [TextArea(0, 20)]
    public string description;
    public string[] parameter;
}
