using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update





   private Rigidbody2D rb;
    private BoxCollider2D coll;
  
    private SpriteRenderer sprite;
    [SerializeField] private LayerMask jumpableGround;

    private Animator anim;
   [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float jumpForce = 14;    
    float dirX = 0f;
    private enum MovementState { idel, running, jumping, falling   }

    [SerializeField] private AudioSource jumpSoundEffect;

   private void Start()
    {
     
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

    }









    // Update is called once per frame
   private void Update()
    {

         dirX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);






        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSoundEffect.Play();

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }




        UpdateAnimationUpdate();
        


    }
    private void UpdateAnimationUpdate()
    {

        MovementState state;

       


        if (dirX > 0f)
        {
           state  = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idel;
        }

        if( rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if ( rb.velocity.y < -.1f)
        {
            state= MovementState.falling;
        }


        anim.SetInteger("state", (int)state);

    }





    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }







}
