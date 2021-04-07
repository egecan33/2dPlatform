using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    public int healt = 100;
    public virtual void TakeDamage(int damage)
    {
        healt -= damage;      
    }
    protected virtual void HitFeedBack()
    {

    }
    protected virtual void OnDeath()
    {
        Debug.Log("Öldün olum");
    }
    protected bool CheackIfWeDead()
    {
        if (healt <= 0)
        {
            healt = 0;
            return true;
        }
        return false;
    }
}
