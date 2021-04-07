using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public float attackRange;

    GameObject attaclkPoint;
    LayerMask LayerMask;

    public bool isAttacking = false;
    void Awake()
    {
            
    }
    void Update()
    {
        
    }
    public void Attack()
    {
        Collider2D[] hitResults = Physics2D.OverlapCircleAll(attaclkPoint.transform.position,attackRange,LayerMask);
        if (hitResults==null)
            return;
        foreach (Collider2D hit in hitResults)
        {

        }
    }
}
