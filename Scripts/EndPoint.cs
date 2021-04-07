using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    //[SerializeField]
    BoxCollider2D BoxCollider2D;
    [SerializeField]
    GameObject block1, block2;

    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        block1.SetActive(false);
        block2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            block1.SetActive(true);
            block2.SetActive(true);
        }
    }
}
