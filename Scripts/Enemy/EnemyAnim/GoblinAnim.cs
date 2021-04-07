using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinAnim : MonoBehaviour
{
    Animator Animator;

    void Awake()
    {
        Animator = GetComponent<Animator>();
    }

    public void SetRun(bool flag)
    {
        Animator.SetBool("IsRunning", flag);
    }
    public void SetDeath(bool flag)
    {
        Animator.SetBool("IsDeath", flag);
    }
    public void TriggerAttack(bool flag)
    {
        Animator.SetTrigger("Attack");
    }
    public void TriggerHurt(bool flag)
    {
        Animator.SetTrigger("Hit");
    }

}
