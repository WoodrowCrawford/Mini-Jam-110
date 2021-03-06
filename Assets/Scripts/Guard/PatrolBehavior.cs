using UnityEngine;

public class PatrolBehavior : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField]
    private Transform leftEdge;
    [SerializeField]
    private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField]
    private Transform enemy;

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
        initScale = enemy.localScale;
    }


    private void Update()
    {
        if(movingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
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
            if(enemy.position.x <= rightEdge.position.x)
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
        enemy.localScale = new Vector3(Mathf.Abs( initScale.x) * _direction, initScale.y, initScale.z);

        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed,
           enemy.position.y, enemy.position.z);
    }
}
