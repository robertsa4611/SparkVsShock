using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Change GetAxis to GetAxisRaw to have character stop immediately after pressing the move buttons
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * 8.5f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
	    {
		    rb.velocity = new Vector2(rb.velocity.x, 16f);
	    }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
