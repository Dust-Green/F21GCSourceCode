using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    public GameObject sender;


    private void Start()
    {
        rb.velocity = transform.right * speed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if(player != null )
        {
            player.TakeDamage(damage,sender);
        }

        //Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
