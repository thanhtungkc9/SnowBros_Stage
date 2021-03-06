﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnBehaviour : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<PlayerScript>().transform.parent = null;
        //animator.GetComponent<PlayerScript>().transform.position = GlobalControl.respawnPoint;
        animator.GetComponent<PlayerScript>().timeImmortal = 1;
        animator.GetComponent<PlayerScript>().audioPlayer.PlayOneShot(animator.GetComponent<PlayerScript>().audio_respawn);

    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        animator.GetComponent<PlayerScript>().timeImmortal = 1;
        animator.GetComponent<PlayerScript>().currentHealth = animator.GetComponent<PlayerScript>().maxHealth;
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetInteger("CurrentState", 0);
 
        GlobalControl.Lives -= 1;
        animator.GetComponent<PlayerScript>().maxVelocity = GlobalControl.maxVelocity;

    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
