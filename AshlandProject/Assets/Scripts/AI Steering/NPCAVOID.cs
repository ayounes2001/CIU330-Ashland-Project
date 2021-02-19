using System;
using System.Collections;
using System.Collections.Generic;


using UnityEngine;

namespace AnthonyY
{
    public class NPCAVOID : MonoBehaviour
    {
        // Start is called before the first frame update
        private Rigidbody rb;
        public float speed;
        public float originalSpeed;

        public float jumpForce;


        public int damageAmount = 20;
       
        public float distToGround;
        
        public bool isGrounded;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            
            rb.AddRelativeForce(0, 0, speed);

                       
        }
        //TODO
        //HealthBased code in here
        private void OnCollisionEnter(Collision other)
        {
            // ReSharper disable once Unity.NoNullPropagation
            other.gameObject?.GetComponent<PlayerMovement>()?.GetComponent<HealthComponent>()?.TakeHp(damageAmount);
        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Log"))
            {
                if (!Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
                    isGrounded = false;
                
                }
                else
                {
                    isGrounded = true;
                }
            }
        }

        void Death()
        {
            gameObject.GetComponent<HealthComponent>()?.Death();
        }
    }
}