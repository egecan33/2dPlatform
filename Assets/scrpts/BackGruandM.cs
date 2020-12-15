using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGruandM : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D BackGruand;
    Vector3 distins;
    int speed = 5;
    float move;
    void Awake()
    {
        distins=Player.transform.position - BackGruand.transform.position;
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        BackGruand.velocity = new Vector2(move*(0.3f), 0);

    }
}
