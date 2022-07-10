using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrabObject : MonoBehaviour
{

    public GameObject GrabRange;
    public Rigidbody2D Enemy;

    public Transform CarriedObject;

    public Animator animator;


    [SerializeField]
    private float _throwPower = 2.0f;

    private bool _grab = false; //used when the player is pressing the grab button
    private bool _canGrab = false; //used to check if the player can grab


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Debug.Log("Can grab");
            _canGrab = true;
        }
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            _canGrab = false;
            Debug.Log("can No longer grab");
        }
    }
    public void Grab(InputAction.CallbackContext context)
    {
        if (context.performed && _canGrab)
        {
            _grab = true;
           
            animator.Play("Cultist_Lift_Anim");
    
            Enemy.transform.position = CarriedObject.transform.position;
            Debug.Log("I am grabbing now");

           
        }
        else
        {
            
           

            if (_grab)
            {
                _grab = false;
                Enemy.AddForce(new Vector2(_throwPower, 60), ForceMode2D.Impulse);
            }
            animator.SetBool("Grab", false);


            _grab = false;
            Debug.Log("not grabbing");
        }
       
    }


    

    public void Update()
    {
        //Update the location of the carried object
        if(_grab)
        {
            Enemy.transform.position = CarriedObject.transform.position;
             
        }
    }

    
}
