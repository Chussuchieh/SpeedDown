using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("动画")]
    Animator animator;
    bool isDead;
    [Header("移动")]
    bool canMove =true;
    public float moveSpeed;
    float Xvelocity;
     
    [Header("触底判断")]
    public LayerMask ground;
    public LayerMask fan;
    public Vector2 offSet;
    public Vector2 size;
    private void Awake() 
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();    
    }
    void Update()
    {
        SwitchAnim();
        Move();
        IsOnFan();
    }
    void Move()
    {
        if(canMove)
        {
            Xvelocity=Input.GetAxisRaw("Horizontal");
            rb.velocity=new Vector2(Xvelocity*moveSpeed,rb.velocity.y);
            if(Xvelocity!=0)    transform.localScale=new Vector3(Xvelocity,1,1);
        }
    }
    void SwitchAnim()
    {
        animator.SetFloat("Speed",Mathf.Abs(Xvelocity));
        animator.SetBool("Fall",!IsOnGround());
    }
    public void AfterDeadAnim()
    {
        GameController.instance.GameOver(false);
        Destroy(gameObject);
    }
    bool IsOnGround()
    {
        return Physics2D.OverlapBox((Vector2)transform.position+offSet,size,0,ground);
    }
    void IsOnFan()
    {
        if(Physics2D.OverlapBox((Vector2)transform.position+offSet,size,0,fan))
        {
            rb.velocity=new Vector2(rb.velocity.x,10.5f);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Spikes"))
        {
            DeadState();
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Spikes"))
        {
            DeadState();
        }    
    }

    void DeadState()
    {
            isDead=true;
            canMove=false;
            rb.gravityScale=0;
            rb.velocity=Vector2.zero;
            animator.SetTrigger("Dead");
    }


    private void OnDrawGizmos() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position+offSet,size);
    }
}
