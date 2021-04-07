using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject BlockObject;
    BoxCollider2D BoxCollider2D;
    public KarekterAnim KarekterAnim;
    AudioSource AudioSource;

    public bool IsBlocking=false;
    void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        //KarekterAnim = GetComponent<KarekterAnim>();
        //BlockObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            ShieldUp();
        }
        else
        {
            ShieldDown();
        }
    }
    public void deneme()
    {
        KarekterAnim.TriggerBlockAnimation();
        AudioSource.PlayOneShot(AudioSource.clip);
    }
    void ShieldUp()
    {
        BoxCollider2D.enabled = true;
        IsBlocking = true;
        KarekterAnim.PlayBlockAnim();
    }
    void ShieldDown()
    {
        IsBlocking = false;
        BoxCollider2D.enabled = false;
        KarekterAnim.StopBlockAnim();
    }
}

