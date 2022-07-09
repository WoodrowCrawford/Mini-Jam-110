using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrabObject : MonoBehaviour
{

    public GameObject GrabRange;
    public GameObject Enemy;

    public Transform CarriedObject;

    public Animator animator;

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

    public void Grab(InputAction.CallbackContext context)
    {
        if (context.performed && _canGrab)
        {
            _grab = true;
            animator.SetBool("Grab", true);


            Enemy.transform.position = CarriedObject.transform.position;
            Debug.Log("grab true");
        }
        else if(context.canceled)
        {
            _grab = false;
            animator.SetBool("Grab", false);
            Debug.Log("grab false");
        }
    }
}
