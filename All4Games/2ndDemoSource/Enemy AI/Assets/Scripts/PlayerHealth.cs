using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int pushback = -2;
    public Animator animator;
    public Knockback knockback;
   
    public GameObject deathEffect;
    public void TakeDamage(int damage, GameObject sender)
    {
        
        knockback.PlayKnockback(sender);
        Debug.Log("I'm hit!");
        animator.SetTrigger("IsHit");
        health = health - damage;
        Debug.Log("Current HP:: " + health);
        //Play damage animation
        //Move character back a bit. 
        //Make character invul???
        
        
    }
    
    void Die()
    {
        //Brackys uses this to just reload the scene but Idk if that's what we'll do 
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
