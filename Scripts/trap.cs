using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public int dmg=200;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Debug.Log("sa");
            collision.gameObject.GetComponent<IDamageable<int>>().TakeDamage(dmg);
        }
    }
}
