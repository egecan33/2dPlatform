using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D Rigidbody2D;
    public int damage = 25;



    void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.velocity = transform.right * speed;
        Destroy(gameObject, 0.7f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.GetComponent<IDamageable<int>>().TakeDamage(damage);
            Destroy(gameObject);
        }
        /*
        RailingHealt railingHealt = collision.GetComponent<RailingHealt>();
        if (railingHealt != null)
        {
            railingHealt.TakeDamage(damage);
            Destroy(gameObject);
        }
        */


    }

}
