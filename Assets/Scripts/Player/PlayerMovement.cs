using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    public Transform groundCheck;

    public LayerMask groundLayer;

    public Animator animator;

    private GrabObject grabObject;
    private float horizontal;

    [SerializeField]
    private float speed = 8f;

    [SerializeField]
    private float jumpingPower = 16f;

    private bool _isFacingRight = true;
    private bool _isMoving = false;
    private bool _isJumping = false;

    private string currentState;


    //Animation States
    const string CULTIST_ATTACK = "Cultist_Attack_Anim";
    const string CULTIST_DEATH = "Cultist_Death_Anim";
    const string CULTIST_HIT = "Cultist_Hit_Anim";
    const string CULTIST_IDLE = "Cultist_Idle_Animation";
    const string CULTIST_IDLE_LIFT = "Cultist_Idle_Lift_Anim";
    const string CULTIST_LIFT = "Cultist_Lift_Anim";
    const string CULTIST_RUN = "Cultist_Run_Animation";
    const string CULTIST_RUN_CARRY = "Cultist_Run_Carry_Anim";
    const string CULTIST_THROW = "Cultist_Throw_Anim";
    const string CULTIST_WALK = "Cultist_Walk_Animation";
    const string CULTIST_WALK_CARRY = "Cultist_Walk_Carry_Anim";
    const string CULTIST_JUMP = "Cultist_Jump";
    const string CULTIST_JUMP_CARRY = "Cultist_Jump_Carrying";



    // Start is called before the first frame update
    void Start()
    {
        grabObject = GetComponent<GrabObject>();
        animator = GetComponent<Animator>();
        ChangeAnimationState(CULTIST_IDLE);  
        
        
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


        /////////Changes animation states for moving
        if (_isMoving && IsGrounded())
        {
            ChangeAnimationState(CULTIST_RUN);
        }
        else if(!_isMoving && IsGrounded())
        {
            ChangeAnimationState(CULTIST_IDLE);
        }
    }


    public void ChangeAnimationState(string newState)
    {
        //stop the same animation from interrupting itself
        if (currentState == newState)
        {
            return;
        }

        //play the animation
        animator.Play(newState);

        //reassign the current state
        currentState = newState;
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
        _isMoving = true;
        horizontal = context.ReadValue<Vector2>().x * speed;
        

        //Make the animation move

        //What happens if the button was released
        if(context.canceled)
        {
            _isMoving = false;
        }    
    }


    public void Quit(InputAction.CallbackContext context)
    {
        Application.Quit();
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
   
}
