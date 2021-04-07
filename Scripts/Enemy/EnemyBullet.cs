using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    Rigidbody2D Rigidbody2D;
    public int Damage = 25;



    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        KarekterAnim karekterAnim = collision.GetComponent<KarekterAnim>();
        if (collision.gameObject.tag.Equals("Shield"))
        {
            Destroy(gameObject);
            Block block = collision.GetComponent<Block>();
            block.deneme();
            Debug.Log("Shield hit");
        }
        else if (collision.gameObject.tag.Equals("Player"))
        {
            collision.GetComponent<IDamageable<int>>().TakeDamage(Damage);
            Destroy(gameObject);
            karekterAnim.TriggerHurtAnimation();
        }

    }

}