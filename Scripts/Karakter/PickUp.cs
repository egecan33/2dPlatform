using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public LayerMask IteamLayerMask;
    PolygonCollider2D PolygonCollider2D;
    RaycastHit2D raycastHit2D;
    void Awake()
    {
        PolygonCollider2D = GetComponent<PolygonCollider2D>();    
    }

    void Update()
    {       
        if (IsClose())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Destroy(raycastHit2D.collider.gameObject);   
            }
            
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Iteam"))
        {
            Debug.Log("Iteam");
        }
    }
    public bool IsClose()
    {
        raycastHit2D = Physics2D.BoxCast(PolygonCollider2D.bounds.center, PolygonCollider2D.bounds.size, 0f, Vector2.one, 2f, IteamLayerMask);
        
        return raycastHit2D.collider != null;
    }
}
