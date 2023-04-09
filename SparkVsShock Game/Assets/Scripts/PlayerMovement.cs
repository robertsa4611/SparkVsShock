using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private bool doubleJump = false;
    private bool doubleJumpActive = false;
    private static int shoesVar;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float yVelJumpReleaseMod = 2f;

    [SerializeField] private Image shoeImage1;
    [SerializeField] private Image shoeImage2;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
    var jumpInputReleased = Input.GetButtonUp("Jump"); 
    shoesVar = ItemCollector.shoes;
        if (shoesVar == 2)
        {
            doubleJumpActive = true;
        }

        //Change GetAxis to GetAxisRaw to have character stop immediately after pressing the move buttons
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * 8.5f, rb.velocity.y);

        if (IsGrounded() && !Input.GetButtonDown("Jump") && doubleJumpActive)
        {
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
	    {
		    if (IsGrounded() || doubleJump && doubleJumpActive)
            {
                rb.velocity = new Vector2(rb.velocity.x, 16f);
                doubleJump = !doubleJump;
            }
	    }

        if(jumpInputReleased && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / yVelJumpReleaseMod);
        }
    }

   private bool IsGrounded()
   {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
   }

    //death stuff
  /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }*/

    
}
