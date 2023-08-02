using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillianAttacks : MonoBehaviour
{
    public int meleeDamage = 10;
    public int rangeDamage = 5;
    public Vector3 attackOffset;

    public float attackRange = 1f;
    public LayerMask attackMask;

   
    public Transform firePoint;
    public GameObject projectilePrefab;
    public GameObject sender;

    public void Attack()
    {

        Vector3 pos = transform.position;
        sender = transform.parent.gameObject;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<PlayerHealth>().TakeDamage(meleeDamage, sender);
        }
    }

    public void Shoot()
    {
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
       
    }
    
}
