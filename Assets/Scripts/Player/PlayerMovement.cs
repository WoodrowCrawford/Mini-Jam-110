using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    //The rigidbody for the player
    public Rigidbody2D rb;



    //Ground Check for player
    public Transform groundCheck;

    //What layer the player will check for
    public LayerMask groundLayer;

    public Animator animator;


    private float horizontal;

    [SerializeField]
    private float speed = 8f;


    [SerializeField]
    private float jumpingPower = 16f;

    private bool _isFacingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        

        if (!_isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if(_isFacingRight && horizontal < 0f)
        {
            Flip();
        }

        if(Keyboard.current.escapeKey.wasPressedThisFrame)
        {
          
        }
    }
    

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            //Play jumping animation

            //Play jumping sound
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            //Play falling animation
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //Make the animation move



       
    }

    public void Quit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }


   
}
