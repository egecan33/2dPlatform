using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireball;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }   
    }

    void Shoot()
    {
        Instantiate(fireball, firePoint.position, firePoint.rotation);
    }
}
