using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    private float waitTime;
    public float startTime=1;

    Transform[] moveSpots;
    public Transform walkleft;

    bool left, right;
    
    void Start()
    {
        waitTime = startTime;
        //walkleft = GetComponent<Transform>();
        walkleft.position = new Vector2(walkleft.position.x + Random.Range(-1, 1), walkleft.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(waitTime);
        transform.position=Vector2.MoveTowards(transform.position,walkleft.position, 2f *Time.deltaTime);
        if (Vector2.Distance(transform.position, walkleft.position) <0.2f)
        {
            if (waitTime<=0)
            {
                walkleft.position = new Vector2(walkleft.position.x + Random.Range(-2, 0), walkleft.position.y);
                if (Vector2.Distance(transform.position,walkleft.position)<0.2f)
                {
                    walkleft.position = new Vector2(walkleft.position.x + Random.Range(0, 2), walkleft.position.y);
                }
                waitTime = startTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
