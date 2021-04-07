using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    GoblinAnim GoblinAnim;
    ECombat ECombat;
    bool isMoving;

    void Awake()
    {
        ECombat = GetComponent<ECombat>();
        GoblinAnim = GetComponent<GoblinAnim>();
    }

    void Update()
    {
        Chase();  
    }
    
    public void Chase() {
        playerDistance = Vector3.Distance(player.position, transform.position);
        if (playerDistance < 10f && playerDistance > 1.8f)
        {
            SetEnemyrDirection(0, 180);
            if (ECombat.isAttacking==false)
            {
                GoblinAnim.SetRun(true);
                isMoving = true;
                transform.position = Vector2.MoveTowards(transform.position, player.position, rotationSpeed * Time.deltaTime);
            }   
        }
        else
            GoblinAnim.SetRun(false);
        if (playerDistance<1.8f)
        {
            //ECombat.Attack();
            ECombat.isAttacking = true;
            GoblinAnim.TriggerAttack(true);
        }
        else
        {
            ECombat.isAttacking = false;
        }
        
    }
    protected override void SetEnemyrDirection(int y1, int y2)
    {
        base.SetEnemyrDirection(y1, y2);
    }

}
