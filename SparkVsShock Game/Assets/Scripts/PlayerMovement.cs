using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private float moveX = 0f;
    private SpriteRenderer sprite;
  [SerializeField]  private float moveSpeed = 8.5f;
  [SerializeField]  private float jumpForce = 16f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float yVelJumpReleaseMod = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
    var jumpInputReleased = Input.GetButtonUp("Jump"); 


        //Change GetAxis to GetAxisRaw to have character stop immediately after pressing the move buttons
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
	    {
		    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
	    }
        //Animation stuff do not touch me or I will touch u
       
        
         if(jumpInputReleased && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / yVelJumpReleaseMod);
        }

        UpdateAnimationUpdate();
    }
        private void UpdateAnimationUpdate()
        {
            if (moveX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;

        }
        else if (moveX < 0f)
           {
                        anim.SetBool("running", true);
                        sprite.flipX = true;
           } 
            else
            {
                            anim.SetBool("running", false);
            }
        }





    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    //death stuff
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }


}
