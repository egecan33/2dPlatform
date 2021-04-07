using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float playerDistance, rotationSpeed, ShootingRate = 0.25f;

    public Transform FirePoint;
    public GameObject BULLET;

    Vector3 direction;

    bool flag = false;
    public float shootCooldown;
    int speed = 4;

    private void Awake()
    {
        shootCooldown = 200;
    }


    void Update()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);
        //Vector3 direction = player.position - transform.position;

        chase();
        if (playerDistance < 10f)
        {
            if (shootCooldown > 0)
            {
                shootCooldown -= 1;
            }
            if (shootCooldown <= 0)
            {
                EnemyShoot();
                shootCooldown = 200;

            }
        }
        SetEnemyrDirection();
    }
    protected virtual void chase()
    {
        playerDistance = Vector3.Distance(player.position, transform.position);
        if (playerDistance < 15f && playerDistance > 9f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, rotationSpeed * Time.deltaTime);
        }
    }
    void EnemyShoot()
    {
        Instantiate(BULLET, FirePoint.position, FirePoint.rotation);
    }
    protected virtual void SetEnemyrDirection(int y1=180,int y2=0)
    {
        Vector3 direction = player.position - transform.position;
        if (direction.x > 0)
            transform.rotation = Quaternion.Euler(0, y1, 0);
        else
            transform.rotation = Quaternion.Euler(0, y2, 0);
    }
}
