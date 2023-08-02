using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenIdle : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    VillianControls villianControl;

    public float closeEnough = 4.5f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        villianControl = animator.GetComponent<VillianControls>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        villianControl.LookAtPlayer();

        if (Vector2.Distance(player.position, rb.position) <= closeEnough)
        {
            animator.SetFloat("DistanceAway", closeEnough);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
    }

    
}
