using System;
using System.Collections;
using System.Collections.Generic;
using Niall;
using UnityEngine;

namespace AnthonyY
{
    public class DemoTriggerFollow : MonoBehaviour
    {
        [Header("AI scripts")]
        public TurnTowardsBehaviour aiScript;
        public NPCAVOID avoidScript;
        public AvoidBehaviour leftFeeler;
        public AvoidBehaviour rightFeeler;

        public event Action playerMetEvent;
        private void OnTriggerEnter(Collider other)
        {
                 playerMetEvent?.Invoke();
             // Debug.Log("hi");
                aiScript = GetComponent<TurnTowardsBehaviour>();
                aiScript.enabled = true;
                avoidScript = GetComponent<NPCAVOID>();
                avoidScript.enabled = true;

                leftFeeler = GetComponent<AvoidBehaviour>();
                leftFeeler.enabled = true;

            rightFeeler = GetComponent<AvoidBehaviour>();
            rightFeeler.enabled = true;



        }
     
    }
}

