﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkBehaviour : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
           
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        float h = Input.GetAxisRaw("Horizontal");
        Transform transform = animator.GetComponent<PlayerScript>().transform;
        if (h == 0&& (animator.GetComponent<PlayerScript>().isMoveLeft==false&& animator.GetComponent<PlayerScript>().isMoveRight==false))
        {
            animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_IDLE);
        }
        if (Input.GetKey(KeyCode.J) || Input.GetKeyDown(KeyCode.J) || animator.GetComponent<PlayerScript>().isShoot)
        {

            animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_THROW);
        }
        else if (Input.GetKeyDown(KeyCode.K) || animator.GetComponent<PlayerScript>().isJump)
        {

            if (animator.GetComponent<PlayerScript>().grounded && animator.GetInteger("CurrentState") != animator.GetComponent<PlayerScript>().STATE_JUMP)
            {
                //animator.GetComponent<PlayerScript>().grounded = false;
                animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>(). STATE_JUMP);
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
