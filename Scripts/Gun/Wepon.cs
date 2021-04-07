using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireball;
    KarekterAnim KarekterAnim;
    private void Awake()
    {
        KarekterAnim = GetComponent<KarekterAnim>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            KarekterAnim.TriggerAttackAnimation();
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(fireball, firePoint.position, firePoint.rotation);
    }
}