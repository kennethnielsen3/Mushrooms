using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (UserControl))]
[RequireComponent(typeof (Rigidbody2D))]
public class CharacterControler : MonoBehaviour {
    
    [SerializeField] private LayerMask m_WhatIsGround;
    private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;
    private Transform m_CeilingCheck;
    const float k_CeilingRadius = .2f;
    private Rigidbody2D m_Rigidbody2D;
    public GameObject hitBox;
    private Animator anim;
    private bool canAttack = true;
    private bool crawl = false;
    private bool facingRight = true;
    private float jumpTimeCounter;
    private bool jumping = false;


    void Start()
    {
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UserControl.attack += Attack;
        UserControl.jumpOn += JumpOn;
        UserControl.jumpHold += JumpHold;
        UserControl.jumpOff += JumpOff;
        UserControl.crouchOn += Crouch;
        UserControl.crouchOff += Stand;
        jumpTimeCounter = StaticVars.jumpTime;
    }

    void Update()
    {
        if(StaticVars.grounded)
        {
            jumpTimeCounter = StaticVars.jumpTime;
        }
        
        if(crawl && !StaticVars.ceiling)
        {
            crawl = false;
            StaticVars.crouching = false;
            canAttack = true;
        }

        anim.SetBool("Crouch", StaticVars.crouching);
    }

    void FixedUpdate()
    {
        StaticVars.grounded = false;
        StaticVars.ceiling = false;

        // circlecast to check for ground
        Collider2D[] collidersGround = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < collidersGround.Length; i++)
        {
            if (collidersGround[i].gameObject != gameObject)
            {
                StaticVars.grounded = true;   
            }
        }

        // circlecast to check for ceiling
        Collider2D[] collidersCeiling = Physics2D.OverlapCircleAll(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround);
        for (int i = 0; i < collidersCeiling.Length; i++)
        {
            if (collidersCeiling[i].gameObject != gameObject)
            {
                StaticVars.ceiling = true;   
            }
        }

    } 


    //Jump
    public void JumpOn()
    {
        if(StaticVars.grounded && !StaticVars.crouching)
        {
            jumping = true;
            m_Rigidbody2D.AddForce(new Vector2(0f, StaticVars.jumpPower));
        }
    }
    public void JumpHold()
    {
        if(jumping)
        {
            if(jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.deltaTime;
                m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, StaticVars.jumpPowerHold);
            }
        }
    }
    public void JumpOff()
    {
        jumping = false;
        jumpTimeCounter = 0;
    }


    //knockback
    public void KnockBack(Vector2 direction, float knockBack)
    {
        StaticVars.controlActive = false;
        m_Rigidbody2D.velocity = new Vector3(0, 0, 0);
        m_Rigidbody2D.AddForce(direction * knockBack);
        Invoke("ControlReturn", StaticVars.knockBackTime); 
    }
       
    void ControlReturn()
    {
        if(StaticVars.alive)
        {
            StaticVars.controlActive = true;
        }
    }


    public void Move(float LR)
    {
        StaticVars.LR = LR;
        //Movement
        
        if(StaticVars.crouching)
        {
             m_Rigidbody2D.velocity = new Vector2(LR * (StaticVars.moveSpeed / 2), m_Rigidbody2D.velocity.y);
        } 
        else 
        {
            m_Rigidbody2D.velocity = new Vector2(LR * StaticVars.moveSpeed, m_Rigidbody2D.velocity.y);
        }


         // Flip Player
        if (StaticVars.LR > 0 && !facingRight)
        {
            Flip();
        } 
        else if (StaticVars.LR < 0 && facingRight)
        {
            Flip();
        }
    }


    public void Crouch()
    {
        if(StaticVars.grounded)
        {
            StaticVars.crouching = true;
            canAttack = false;
        } 
    }
    public void Stand()
    {  
        if(!StaticVars.ceiling)
        {
            StaticVars.crouching = false;
            canAttack = true;
        }
        if(StaticVars.ceiling)
        {
            crawl = true;
        }

    }

    //Flip Controller
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //Attack
    public void Attack()
    {
        if(!StaticVars.attacking && canAttack)
        {
            StartCoroutine (AttackRun());
        }
    }

    public IEnumerator AttackRun()
    {
        StaticVars.attacking = true;
        hitBox.SetActive(true);
        StartCoroutine (AttackCoolDown());

        yield return new WaitForSeconds(0.2f);
       
        StaticVars.attacking = false;
        hitBox.SetActive(false);
    }
    public IEnumerator AttackCoolDown()
    {
        canAttack = false;

        yield return new WaitForSeconds(0.3f);

        canAttack = true;
    }
    
}