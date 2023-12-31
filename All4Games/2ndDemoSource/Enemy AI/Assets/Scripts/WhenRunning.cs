using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenRunning : StateMachineBehaviour 
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 1.5f;
    public float attackRange = 0.5f;
    public float tooFarShootHim = 2f;
    private int chanceToShoot;
    VillianControls villianControl;
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
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
        //If player is X distance away. roll dice. if die roll equals...something. Shoot him. Otherwise keep walking. 
        //Debug.Log(Vector2.Distance(player.position, rb.position));
        if(Vector2.Distance(player.position, rb.position) >= tooFarShootHim)
        {
            chanceToShoot = Random.Range(1, 100);
            if (chanceToShoot <= 20)
            {
                //Debug.Log("You're too far away!");
                animator.SetTrigger("Shoot");
            }
            
        }
        if( Vector2.Distance(player.position,rb.position) <= attackRange)
        {
           
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("Shoot");
    }

}
