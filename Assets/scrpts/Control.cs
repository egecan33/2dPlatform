using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    private int speed = 5;
    PolygonCollider2D PolygonCollider2D;
    public LayerMask zeminLayermask;

    int flag;


    void Start()
    {

        PolygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        flag = (int)Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0,0);
        transform.position += movement * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 180f, 0f);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, 0f);
        }
        
        if (Yerdemi() && Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D.AddForce(Vector2.up*500);
        }
    }
    public bool Yerdemi()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(PolygonCollider2D.bounds.center, PolygonCollider2D.bounds.size, 0f, Vector2.down, 1f, zeminLayermask);
        return raycastHit2d.collider != null;
    }
}
