using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    
    [SerializeField] private bool active = true;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float yVelJumpReleaseMod = 2f;

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


        //Change GetAxis to GetAxisRaw to have character stop immediately after pressing the move buttons
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * 8.5f, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
	    {
		    rb.velocity = new Vector2(rb.velocity.x, 16f);
	    }

        if(jumpInputReleased && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / yVelJumpReleaseMod);
        }

        if(!active)
        {
            return;
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