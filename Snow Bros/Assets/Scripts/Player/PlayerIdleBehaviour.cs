﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleBehaviour : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<PlayerScript>().gameObject.layer = 13;
        if (animator.GetInteger("CurrentState") == 9)
            animator.GetComponent<PlayerScript>().timeImmortal = 4;

    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0||animator.GetComponent<PlayerScript>().isMoveLeft==true|| animator.GetComponent<PlayerScript>().isMoveRight==true)
        {
                if (animator.GetInteger("CurrentState") != animator.GetComponent<PlayerScript>().STATE_WALK)
                    animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_WALK);
             
        }

        
        if (Input.GetKey(KeyCode.J)||animator.GetComponent<PlayerScript>().isShoot)
        {

            {
                animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_THROW);
            }

        }
        else if (Input.GetKeyDown(KeyCode.K) || animator.GetComponent<PlayerScript>().isJump)
        {
            if (animator.GetComponent<PlayerScript>().grounded && animator.GetInteger("CurrentState") != animator.GetComponent<PlayerScript>().STATE_JUMP)
            {
                //animator.GetComponent<PlayerScript>().grounded = false;
                animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_JUMP);
            }
        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
