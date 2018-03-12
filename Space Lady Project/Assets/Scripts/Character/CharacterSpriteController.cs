using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteController : MonoBehaviour {

	private Animator anim;
	private SpriteRenderer spriteRenderer;
	private bool facingRight = true;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	 void Update()
    {
        anim.SetBool("Grounded", StaticVars.grounded);
        anim.SetBool("Attack", StaticVars.attacking);
		anim.SetFloat("LR", Mathf.Abs(StaticVars.LR));
        anim.SetBool("Crouch", StaticVars.crouching);
		anim.SetBool("Alive", StaticVars.alive);
        

        if(StaticVars.invincible && StaticVars.alive)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5F);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
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

	private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
