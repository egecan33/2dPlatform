using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float playerDistance,rotationSpeed,ShootingRate=0.25f;

    public Transform FirePoint;
    public GameObject BULLET;

    bool flag = false;
    float Healt = 100f;
    float shootCooldown;
    int speed = 4;

    private void Awake()
    {
        shootCooldown = 50;
    }


    void Update()
    {
        playerDistance = Vector3.Distance(player.position,transform.position);
        Vector3 direction = player.position - transform.position;

        if (playerDistance<15f && playerDistance>9f)
        {
            chase();     
        }
        if (playerDistance < 10f)
        {
            if (shootCooldown > 0)
            {
                shootCooldown -= 1;
            }
            if (shootCooldown == 0)
            {
                EnemyShoot();
                shootCooldown = 75;
                
            }
        }
        if (direction.x>0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
   
    public void TakeDamge(int damge)
    {
        Healt -= damge;
        if (Healt<=0)
        {
            Destroy(gameObject);
        }
    }
    void chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, rotationSpeed * Time.deltaTime);
        
    }
    void EnemyShoot()
    {
        Instantiate(BULLET, FirePoint.position, FirePoint.rotation);
    }
}
