using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpBehaviour : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<PlayerScript>().playerBody.AddForce(new Vector2(0, GlobalControl.jumpForce));
 
         animator.GetComponent<PlayerScript>().audioPlayer.PlayOneShot(animator.GetComponent<PlayerScript>().audio_jump);
        Debug.Log("Jump");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        /*
        float h = Input.GetAxisRaw("Horizontal");
        if (h != 0 && animator.GetComponent<PlayerScript>().isMoveLeft == false && animator.GetComponent<PlayerScript>().isMoveRight == false
            && animator.GetComponent<PlayerScript>().grounded)
        {
            animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_WALK);
        }
        else
        {

            animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_IDLE);

        }*/
        if (Input.GetKey(KeyCode.J) || animator.GetComponent<PlayerScript>().isShoot)
        {

            {
                animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_THROW);
            }

        }
        animator.GetComponent<PlayerScript>().Keyboard_Move();
        if (Input.GetKeyDown(KeyCode.K)
            //|| animator.GetComponent<PlayerScript>().isJump
            && animator.GetComponent<PlayerScript>().walled
            && animator.GetComponent<PlayerScript>().playerBody.velocity.y<0.0f
            && animator.GetComponent<PlayerScript>().isWallJumped==false)
        {
            {
               // animator.GetComponent<PlayerScript>().playerBody.AddForce(new Vector2(0, GlobalControl.jumpForce));
                animator.Play("Jump", -1, 0.0f);
                animator.GetComponent<PlayerScript>().isWallJumped = true;
               // Debug.Log("Jump in Jump");

                //animator.GetComponent<PlayerScript>().playerBody.AddForce(new Vector2(0, GlobalControl.jumpForce/2));
                //animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_JUMP);
                //animator.SetInteger("CurrentState", animator.GetComponent<PlayerScript>().STATE_JUMP);
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
