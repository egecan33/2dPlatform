using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : Healt,IDamageable<int>
{
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        HitFeedBack();
        if (CheackIfWeDead())
        {
            OnDeath();
        }
    }
    protected override void HitFeedBack()
    {
        base.HitFeedBack();
        //this.gameObject.transform.DOShakePosition(0.15f, new Vector3(0.2f, 0, 0), 10, 90);
    }
    protected override void OnDeath()
    {
        base.OnDeath();
        Destroy(gameObject);
        Debug.LogError("OYUN biti");
    }

}
