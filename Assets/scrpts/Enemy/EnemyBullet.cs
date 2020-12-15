using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D Rigidbody2D;
    public int Damge = 25;



    void Start()
    {
        Rigidbody2D.velocity = (transform.right) * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="Player")
        {
            Debug.Log("hellal");
            Destroy(gameObject);
        }
    }
}
