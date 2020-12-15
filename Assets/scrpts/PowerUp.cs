using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Transform Point;
    public LayerMask LayerMask;

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        InRage(2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name== "Player")
        {
            Debug.Log("asdas");
        }
    }
    public void InRage(float range)
    {
        Collider2D[] Iteams = Physics2D.OverlapCircleAll(Point.position, range,LayerMask);
        foreach (var item in Iteams)
        {
            Debug.Log(item.name);
        }
    }
}
