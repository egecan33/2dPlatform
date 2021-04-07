using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarekterAnim : MonoBehaviour
{
    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    public void AirSpeedY(float y)
    {
        animator.SetFloat("AirSpeedY", y);
    }
    public void PlayJumpingAnim()
    {
        animator.SetTrigger("Jump");
    }
    public void Grounded()
    {
        animator.SetBool("Grounded", true);
    }
    public void PlayIdleAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetBool("isJumping", false);
    }

    public void PlayRunningAnim()
    {
        animator.SetInteger("AnimState", 1);
        animator.SetBool("Grounded", true);
        animator.SetBool("isJumping", false);
    }
    public void PlayBlockAnim()
    {
        animator.SetBool("BlockT", true);
    }


    public void StopRunningAnim()
    {
        animator.SetBool("isRunning", false);
        animator.SetInteger("AnimState", 0);
    }
    public void StopBlockAnim()
    {
        animator.SetBool("BlockT", false);
    }

    public void StopJumpingAnim()
    {
        
    }
    public void NotGrounded()
    {
        animator.SetBool("Grounded", false);
    }

    public void TriggerAttackAnimation()
    {
        animator.SetTrigger("Attack1");
    }
    public void TriggerDeathAnimation()
    {
        animator.SetTrigger("Death");
    }
    public void TriggerHurtAnimation()
    {
        animator.SetTrigger("Hurt");
    }
    public void TriggerBlockAnimation()
    {
        animator.SetTrigger("Block");
    }
}
