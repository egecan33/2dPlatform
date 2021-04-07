using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat1 : MonoBehaviour
{
    [SerializeField]
    int Damage;
    [SerializeField]
    float Range;

    [SerializeField]
    GameObject attackPoint;
    [SerializeField]
    LayerMask LayerMask;

    Animator Animator;
    AudioSource AudioSource;

    private int m_currentAttack = 0;
    private float m_timeSinceAttack = 0.0f;

    public bool isAttacking = false;
    
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        Animator = GetComponent<Animator>();
        
    }
    void Update()
    {
        m_timeSinceAttack += Time.deltaTime;
    }
    public void Deneme()
    {
        if (Input.GetKey(KeyCode.Mouse0) && m_timeSinceAttack > 0.25f)
        {
            AudioSource.Play();
            isAttacking = true;
            m_currentAttack++;

            // Loop back to one after third attack
            if (m_currentAttack > 3)
                m_currentAttack = 1;

            // Reset Attack combo if time since last attack is too large
            if (m_timeSinceAttack > 1.0f)
                m_currentAttack = 1;

            // Call one of three attack animations "Attack1", "Attack2", "Attack3"
            Animator.SetTrigger("Attack" + m_currentAttack);


            // Reset timer
            m_timeSinceAttack = 0.0f;
            if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"+m_currentAttack))
            {
                AudioSource.Stop();
            }
        }
        if (!Input.GetKey(KeyCode.Mouse0))
        {
            isAttacking = false;
        }
    }
    public void Attack()
    {
        Collider2D[] hitResults = Physics2D.OverlapCircleAll(attackPoint.transform.position, Range, LayerMask);
        if (hitResults == null)
            return;
        foreach (Collider2D hit in hitResults)
        {
            if (hit.GetComponent<IDamageable<int>>() != null)
            {
                hit.GetComponent<IDamageable<int>>().TakeDamage(Damage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.transform.position, Range);
    }
}
