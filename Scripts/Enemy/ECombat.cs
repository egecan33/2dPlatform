using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ECombat : MonoBehaviour
{
    [SerializeField]
    int attackDamage;
    [SerializeField]
    float attackRange;

    [SerializeField]
    GameObject attackPoint;
    [SerializeField]
    LayerMask targetLayer;

    public bool isAttacking = false;

    public void Attack()
    {

        isAttacking = true;
        Collider2D[] hitResults = Physics2D.OverlapCircleAll(attackPoint.transform.position, attackRange, targetLayer);
        
        if (hitResults == null)
            return;
        foreach (Collider2D hit in hitResults)
        {
            if (hit.gameObject.tag.Equals("Player"))
            {
                if (!Input.GetKey(KeyCode.Mouse1))
                {
                    hit.GetComponent<IDamageable<int>>().TakeDamage(attackDamage);
                    hit.GetComponent<KarekterAnim>().TriggerHurtAnimation();
                }
                
            }
            if (hit.gameObject.tag.Equals("Shield"))
            {
                hit.GetComponent<Block>().deneme();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.transform.position, attackRange);
    }
}
