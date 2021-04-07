using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    #region Public Veriables
    public GameObject deff;
    public GameObject deffPoint;
    public Transform rayCast;
    public Transform left_limit;
    public Transform right_limit;
    public LayerMask raycstMask;
    public LayerMask bulletMask;
    public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public float deffRange;
    #endregion
    #region Private Veriables
    private RaycastHit2D hit2D;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion

    void Awake()
    {
        SelectTarget();
        deffPoint.SetActive(false);
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        SetDeffans();
        if (!attackMode)
        {
            Move();
        }
        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget();
        }
        if (inRange)
        {
            hit2D = Physics2D.Raycast(rayCast.position, transform.right, rayCastLength, raycstMask);
            RaycastDebugger();
        }
        if (hit2D.collider !=null)
        {
            EnemyLogic();
        }
        else if (hit2D.collider==null)
        {
            inRange = false;

        }
        if (inRange==false)
        {
            StopAttack();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            target = collision.transform;
            inRange = true;
            Flip();
        }

    }
    public void RaycastDebugger()
    {
        if (distance>attackDistance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.red);
        }
        else if (attackDistance> distance)
        {
            Debug.DrawRay(rayCast.position, transform.right * rayCastLength, Color.green);
        }
    }
    public void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance>attackDistance)
        {
            StopAttack();
        }
        else if (attackDistance>= distance && cooling==false)
        {
            Attack();
        }
        if (cooling)
        {
            CoolDown();
            anim.SetBool("Attack", false);
        }
    }
    public void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) 
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    public void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }
    public void CoolDown()
    {
        timer -= Time.deltaTime;
        if(timer <=0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }
    public void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }
    public void TriggerCooling()
    {
        cooling = true;
    }
    public void SetDeffans()
    {
        Collider2D[] hitResults = Physics2D.OverlapCircleAll(deff.transform.position, deffRange, bulletMask);
        foreach (Collider2D item in hitResults)
        {
            if (item.gameObject.tag.Equals("Bullet"))
            {
                anim.SetTrigger("IsSSheld");
            }
            
        }
        
    }
    private void OnDrawGizmosSelected()
    {
        if (deff == null)
            return;

        Gizmos.DrawWireSphere(deff.transform.position, deffRange);
    }
    private bool InsideofLimits()
    {
        return transform.position.x > left_limit.position.x && transform.position.x < right_limit.position.x;
    }
    private void SelectTarget()
    {
        float distancetoRight = Vector2.Distance(transform.position, right_limit.position);
        float distanceToLeft = Vector2.Distance(transform.position, left_limit.position);
        if (distanceToLeft>distancetoRight)
        {
            target = left_limit;
        }
        else
        {
            target = right_limit;
        }
        Flip();
    }
    private void Flip()
    {
        Vector3 rotatiton = transform.eulerAngles;
        if (transform.position.x>target.position.x)
        {
            rotatiton.y = 180;
        }
        else
        {
            rotatiton.y = 0;
        }
        transform.eulerAngles = rotatiton;
    }
}
