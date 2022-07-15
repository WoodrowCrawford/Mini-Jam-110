using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrabObject : MonoBehaviour
{
    public Animator animator;

    public Transform grabDetect;
    public Transform boxHolder;

    public float rayDistance;

    public bool hasGrabbedVillager = false;

    private void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, rayDistance);

        if(grabCheck.collider != null && grabCheck.collider.tag == "Villager")
        {
            if (Mouse.current.leftButton.isPressed)
            {
                hasGrabbedVillager = true;

                grabCheck.collider.gameObject.transform.parent = boxHolder;
                grabCheck.collider.gameObject.transform.position = boxHolder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            }

            else
            {
                hasGrabbedVillager = false;

                
                grabCheck.collider.gameObject.transform.parent = null;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
        }
    }



}
