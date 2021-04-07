using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CControl : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    PolygonCollider2D PolygonCollider2D;
    KarekterAnim KarekterAnim;
    CharacterCombat1 CharacterCombat1;

    public LayerMask zeminLayermask;
    public Block Block;
    private int speed = 5;
    
    bool IsRunnig=false;


    void Awake()
    {
        CharacterCombat1 = GetComponent<CharacterCombat1>();
        KarekterAnim = GetComponent<KarekterAnim>();
        PolygonCollider2D = GetComponent<PolygonCollider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!CharacterCombat1.isAttacking && !Block.IsBlocking)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            transform.position += movement * speed * Time.deltaTime;
        }
        if (!Block.IsBlocking)   
            CharacterCombat1.Deneme();
        

        SetWalkAnimator();
        SetCharacterDirection();
        Jump(350);
        //CharacterCombat.Attack();
        if (Input.GetKeyDown(KeyCode.Q))
        {
            KarekterAnim.TriggerDeathAnimation();
        }
        
    }
    public bool IsGruand()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(PolygonCollider2D.bounds.center, PolygonCollider2D.bounds.size, 0f, Vector2.down, 0.5f, zeminLayermask);
        return raycastHit2d.collider != null;
    }
    public void Jump(int jumpPower=200)
    {
        KarekterAnim.AirSpeedY(Rigidbody2D.velocity.y);
        if (IsGruand() && Input.GetKeyDown(KeyCode.Space))
        {
            KarekterAnim.PlayJumpingAnim();
            KarekterAnim.NotGrounded();
            Rigidbody2D.AddForce(Vector2.up * jumpPower);
        }
        else
        {
            KarekterAnim.Grounded();
        }
    }
    void SetCharacterDirection()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void HandleMovememnt()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Rigidbody2D.velocity = new Vector2(-speed, Rigidbody2D.velocity.y);
            KarekterAnim.PlayRunningAnim();

        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                Rigidbody2D.velocity = new Vector2(+speed, Rigidbody2D.velocity.y);
            }
        }
    }
    void SetWalkAnimator()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            KarekterAnim.PlayRunningAnim();
            IsRunnig = true;
        }
        else
        {
            IsRunnig = false;
            KarekterAnim.StopRunningAnim();
        }
    }
}
