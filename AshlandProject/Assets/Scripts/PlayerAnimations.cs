using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimationStates { idle, walking, jumping, running, inair, turningRight, turningLeft }
public class PlayerAnimations : MonoBehaviour
{
    public Animator MovementPAnimator; //ANIMATIONS : 0 = idle , 1 = walking , 2 = jumping , 3 = running , 4 = in air , 5 = TurningRight, 6 = TurningLeft
    public AnimationStates CurrentAnimation;
    public PlayerMovement pMovement;
    bool turning;
    public bool FacingCamera = false;
    Camera SceneCamera;

    private void Start()
    {
        SceneCamera = Camera.main;
    }
    private void Update()
    {
        MovementPAnimator.SetFloat("PlayerSpeed", (pMovement.currentSpeed/400)); //making the players speed influence the walk & run animation speeds
        PlayerTurn();  //checking if turned left or right already
        OrientationCheck(); //checking if player is facing the camera

        switch (CurrentAnimation)
        {
            case  AnimationStates.idle:
               PlayerAnimate(0);
                break;
            case AnimationStates.walking:
               if (turning != true)PlayerAnimate(1);
                break;
            case AnimationStates.jumping:
                PlayerAnimate(2);
                break;
            case AnimationStates.running:
                if (turning != true) PlayerAnimate(3);
                break;
            case AnimationStates.inair:
                PlayerAnimate(4);
                break;
            case AnimationStates.turningRight:
                if (FacingCamera == false) PlayerAnimate(5);    //have to check if facing camera and invert left and right
                else PlayerAnimate(6);                
                break;
            case AnimationStates.turningLeft:
                if (FacingCamera == false) PlayerAnimate(6); 
                else PlayerAnimate(5);
                break;
        }
    }
    void OrientationCheck()
    {
        float dot = Vector3.Dot(transform.forward, (SceneCamera.transform.position - transform.position).normalized);
        if (dot > 0)
        { FacingCamera = true; }
        else { FacingCamera = false; }
    }
    public void PlayerTurn()      
    {
        if (pMovement.input.x > 0 && MovementPAnimator.GetBool("AlreadyTurnedRight") == false)
        {
            MovementPAnimator.SetBool("AlreadyTurnedLeft", false);
            CurrentAnimation = AnimationStates.turningRight;
            turning = true;
            MovementPAnimator.SetBool("AlreadyTurnedRight", true);
        }
        else if (pMovement.input.x < 0 && MovementPAnimator.GetBool("AlreadyTurnedLeft") == false)
        {
            MovementPAnimator.SetBool("AlreadyTurnedRight", false);
            turning = true;
            CurrentAnimation = AnimationStates.turningLeft;
            MovementPAnimator.SetBool("AlreadyTurnedLeft", true);
        }    
    }
    public void PlayerAnimate(int AnimationNumber)
    {
        MovementPAnimator.SetInteger("CurrentAnimation", AnimationNumber);
    }
    public void FinishedTurning()
    {
        turning = false;
    }
}
