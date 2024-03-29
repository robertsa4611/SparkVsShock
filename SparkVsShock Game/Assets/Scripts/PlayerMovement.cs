using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    private bool doubleJump = false;
    private bool doubleJumpActive = false;
    private static int shoesVar;

    private float moveX = 0f;
    private SpriteRenderer sprite;
    [SerializeField] private float moveSpeed = 8.5f;
    [SerializeField] private float jumpForce = 16f;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float yVelJumpReleaseMod = 2f;

    [SerializeField] private bool active = true;

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
    shoesVar = ItemCollector.shoes;
        if (shoesVar == 2)
        {
            doubleJumpActive = true;
        }

        //Change GetAxis to GetAxisRaw to have character stop immediately after pressing the move buttons
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (IsGrounded() && !Input.GetButtonDown("Jump") && doubleJumpActive)
        {
            doubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
	    {
		    if (IsGrounded() || doubleJump && doubleJumpActive)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
	    }

        if(jumpInputReleased && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / yVelJumpReleaseMod);
        }

        UpdateAnimationUpdate();

        if(!active)
        {
            return;
        }
    }

    private void UpdateAnimationUpdate()
    {
        if (moveX > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        } else if (moveX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        } else
        {
            anim.SetBool("running", false);
        }
    }

   private bool IsGrounded()
   {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
   }

     public void Die()
    {
    active = false;
    coll.enabled = false;
    rb.velocity = Vector2.zero; // Stop any movement
    Debug.Log("Player died!"); // Print a message to the console
    
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
    }

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Trap"))
    {
        Die();
    }
}
    
}
