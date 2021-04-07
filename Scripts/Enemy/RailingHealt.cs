using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class RailingHealt : Healt,IDamageable<int>
{
    public SpriteRenderer spriteRenderer;
    AudioSource AudioSource;
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
    }
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
        this.gameObject.transform.DOShakePosition(0.15f, new Vector3(0.4f, 0.1f, 0), 10, 90);
        Tween colorTween = spriteRenderer.DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() => spriteRenderer.DOBlendableColor(Color.white, 0.05f));
        AudioSource.PlayOneShot(AudioSource.clip);
    }
    protected override void OnDeath()
    {
        base.OnDeath();
        this.gameObject.transform.DOShakePosition(0.15f, new Vector3(0.4f, 0.1f, 0), 10, 90);
        Tween colorTween = spriteRenderer.DOBlendableColor(Color.red, 0.1f);
        colorTween.OnComplete(() => Destroy(gameObject));

    }


}
