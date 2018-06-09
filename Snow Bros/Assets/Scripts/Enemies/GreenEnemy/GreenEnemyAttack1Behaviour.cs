﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemyAttack1Behaviour : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (GlobalControl.isPaused) return;
        if (animator.GetComponent<GreenEnemyAI>().isShoot == false)
        {
            animator.GetComponent<GreenEnemyAI>().StartCoroutine(animator.GetComponent<GreenEnemyAI>().Attack1());
            animator.GetComponent<GreenEnemyAI>().isShoot = true;
        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        // animator.GetComponent<GreenEnemyAI>().StartCoroutine(animator.GetComponent<GreenEnemyAI>().Attack1());
        animator.GetComponent<GreenEnemyAI>().isShoot = false;
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
