using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolVillager : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField]
    private Transform leftEdge;
    [SerializeField]
    private Transform rightEdge;

    [Header("Villager")]
    [SerializeField]
    private Transform villager;

    [Header("Movement parameters")]
    [SerializeField]
    private float speed;
    private Vector3 initScale;
    private bool movingLeft;


    [Header("Animator")]
    [SerializeField]
    private Animator animator;


    private void Awake()
    {
        initScale = villager.localScale;
    }


    private void Update()
    {
        if (movingLeft)
        {
            if (villager.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);

            }
            else
            {
                //Change direction
                DirectionChange();
            }
        }
        else
        {
            if (villager.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //Change direction
                DirectionChange();
            }


        }

    }



    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        animator.SetBool("move", true);

        //Make enemy face direction
        villager.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);

        //Move in that direction
        villager.position = new Vector3(villager.position.x + Time.deltaTime * _direction * speed,
           villager.position.y, villager.position.z);
    }
}

